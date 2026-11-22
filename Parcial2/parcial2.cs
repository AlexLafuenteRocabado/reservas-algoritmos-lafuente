// PARCIAL 2 Alex Lafuente Rocabado

#include <algorithm>
#include <chrono>
#include <iostream>
#include <memory>
#include <optional>
#include <queue>
#include <string>
#include <tuple>
#include <unordered_set>
#include <vector>

using namespace std;

struct IReceptorPedidos {
    virtual ~IReceptorPedidos() = default;
    virtual void Registrar(const string& pedido, int plazoMinutos) = 0;
    virtual optional<string> PrepararSiguiente() = 0;   // nullopt si no hay ninguno
    virtual bool EstaPendiente(const string& pedido) = 0;
    virtual int Pendientes() const = 0;
};

struct Pedido {
    string nombre;
    int plazo;
    int llegada;
};

// ---------- SOLUCIÓN INGENUA (vector simple): correcta pero lenta ----------
class ReceptorIngenuo : public IReceptorPedidos {
    vector<Pedido> _lista;
    int _llegadas = 0;

public:
    void Registrar(const string& pedido, int plazoMinutos) override {
        _lista.push_back({pedido, plazoMinutos, _llegadas++});
    }

    optional<string> PrepararSiguiente() override {
        if (_lista.empty()) return nullopt;
        size_t mejor = 0;
        for (size_t i = 1; i < _lista.size(); i++) {
            const Pedido& p = _lista[i];
            const Pedido& m = _lista[mejor];
            if (p.plazo < m.plazo || (p.plazo == m.plazo && p.llegada < m.llegada)) mejor = i;
        }
        string nombre = _lista[mejor].nombre;
        _lista.erase(_lista.begin() + mejor);
        return nombre;
    }

    bool EstaPendiente(const string& pedido) override {
        for (const auto& p : _lista) if (p.nombre == pedido) return true;
        return false;
    }

    int Pendientes() const override { return (int)_lista.size(); }
};

// ---------- TU SOLUCIÓN: heap mínimo + tabla hash ----------
class ReceptorMejorado : public IReceptorPedidos {
    // priority_queue es un max-heap; con este comparador el "mayor" es el de
    // MENOR (plazo, llegada), así que top() es el más urgente.
    struct MasUrgenteQue {
        bool operator()(const Pedido& a, const Pedido& b) const {
            return tie(a.plazo, a.llegada) > tie(b.plazo, b.llegada);
        }
    };

    priority_queue<Pedido, vector<Pedido>, MasUrgenteQue> _heap;
    unordered_set<string> _pendientes;
    int _llegadas = 0;

public:
    // O(log n)
    void Registrar(const string& pedido, int plazoMinutos) override {
        _heap.push({pedido, plazoMinutos, _llegadas++});
        _pendientes.insert(pedido);
    }

    // O(log n)
    optional<string> PrepararSiguiente() override {
        if (_heap.empty()) return nullopt;
        string nombre = _heap.top().nombre;
        _heap.pop();
        _pendientes.erase(nombre);   // si no se quita, EstaPendiente daría true de más
        return nombre;
    }

    // O(1) promedio
    bool EstaPendiente(const string& pedido) override {
        return _pendientes.count(pedido) > 0;
    }

    // O(1)
    int Pendientes() const override { return (int)_pendientes.size(); }
};

// ---------- Guion de pruebas ----------
struct Paso {
    string op, arg;
    int plazo;
    string esperado;
};

static const vector<Paso> Guion = {
    {"registrar", "Torta", 120, ""}, {"registrar", "Galletas", 30, ""},
    {"registrar", "Pan", 120, ""},   {"registrar", "Brazo", 60, ""},
    {"pendientes", "", 0, "4"},
    {"esta", "Galletas", 0, "True"}, {"esta", "Flan", 0, "False"},
    {"preparar", "", 0, "Galletas"}, {"esta", "Galletas", 0, "False"},
    {"preparar", "", 0, "Brazo"},
    {"registrar", "Alfajor", 30, ""},
    {"preparar", "", 0, "Alfajor"}, {"preparar", "", 0, "Torta"}, {"preparar", "", 0, "Pan"},
    {"preparar", "", 0, "(ninguno)"}, {"pendientes", "", 0, "0"},
};

static string Ejecutar(IReceptorPedidos& g, const Paso& s) {
    if (s.op == "registrar") { g.Registrar(s.arg, s.plazo); return ""; }
    if (s.op == "preparar")  { auto r = g.PrepararSiguiente(); return r ? *r : "(ninguno)"; }
    if (s.op == "esta")      { return g.EstaPendiente(s.arg) ? "True" : "False"; }
    return to_string(g.Pendientes());
}

static void Probar(const string& titulo, IReceptorPedidos& g) {
    int bien = 0, total = 0;
    for (const auto& s : Guion) {
        string obtenido = Ejecutar(g, s);
        if (s.op == "registrar") continue;
        total++;
        if (obtenido == s.esperado) bien++;
        else cout << "   MAL en «" << s.op << " " << s.arg << "»: esperado "
                  << s.esperado << ", obtuvo " << obtenido << "\n";
    }
    cout << titulo << ": " << bien << " de " << total << " pasos correctos\n";
}

// ---------- Carga para medir: n pedidos llegan y después se preparan los n ----------
static long long EjecutarCarga(IReceptorPedidos& g, int n) {
    for (int i = 0; i < n; i++)
        g.Registrar("Q" + to_string(i), (int)((i * 6007LL) % 6 + 1) * 15);
    long long control = 0;
    for (int i = 0; i < n; i++) control += (long long)g.PrepararSiguiente()->size();
    return control;
}

// Protocolo: 1 corrida de calentamiento (descartada) + `reps` mediciones; se reporta la mediana.
template <class Fabrica>
static double MedirMs(Fabrica nuevo, int n, int reps, long long& control) {
    { auto g = nuevo(); control = EjecutarCarga(*g, n); }   // calentamiento
    vector<double> ms;
    for (int r = 0; r < reps; r++) {
        auto g = nuevo();                                    // objeto nuevo en cada corrida
        auto t0 = chrono::steady_clock::now();
        control = EjecutarCarga(*g, n);
        auto t1 = chrono::steady_clock::now();
        ms.push_back(chrono::duration<double, milli>(t1 - t0).count());
    }
    sort(ms.begin(), ms.end());
    return ms[ms.size() / 2];
}

int main() {
    ReceptorIngenuo ing;
    ReceptorMejorado mej;
    Probar("ReceptorIngenuo ", ing);
    Probar("ReceptorMejorado", mej);

    auto fIng = [] { return make_unique<ReceptorIngenuo>(); };
    auto fMej = [] { return make_unique<ReceptorMejorado>(); };

    cout << "\nMediana de 5 corridas (ms) tras 1 de calentamiento\n";
    cout << "      n | Ingenuo | Mejorado | control igual\n";
    for (int n : {5000, 10000, 20000, 40000}) {
        long long c1, c2;
        double a = MedirMs(fIng, n, 5, c1);
        double b = MedirMs(fMej, n, 5, c2);
        cout << (n < 10000 ? "   " : "  ") << n << " | " << a << " | " << b
             << " | " << (c1 == c2 ? "si" : "NO") << "\n";
    }

    long long c;
    double b = MedirMs(fMej, 120000, 5, c);
object value = cout << "Mejorado con n = 120000 (jornada normal): " << b << " ms\n";
    return 0;
}