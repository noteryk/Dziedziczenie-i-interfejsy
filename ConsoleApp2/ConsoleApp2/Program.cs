public interface IProdukt
{
    void WyświetlInfo();
    double AktualnaCena();
    int DostępnaIlosc();

}


public class Produkt : IProdukt
{
    protected double _cena;
    protected bool _dostepnosc;
    protected string _opis;
    private string opis;
    private double cena;
    private bool dostepnosc;

    public Produkt(double cena, bool dostepnosc, string opis)
    {
        _cena = cena;
        _dostepnosc = dostepnosc;
        _opis = opis;
    }

    public Produkt(string opis, double cena, bool dostepnosc)
    {
        this.opis = opis;
        this.cena = cena;
        this.dostepnosc = dostepnosc;
    }

    public virtual void WyświetlInfo() { 
    
        Console.WriteLine("Cena:" + _cena +", Dostepnosc: " + _dostepnosc + "Opis: " +_opis);
    }


    public double AktualnaCena()
    {
        return _cena;
    }

    public int DostępnaIlosc()
    {
        if (_dostepnosc)
        {
            return 1;
        } else
        {
            return 0;
        }
    }

    public string Opis()
    {
        return _opis;
    }

}

public class Ksiazka : Produkt
{
    protected string _autor;

    public Ksiazka(string opis, double cena, bool dostepnosc, string autor)
        : base(opis, cena, dostepnosc)
    {
        _autor = autor;
    }

    public override void WyświetlInfo()
    {
        WyświetlInfo();
        Console.WriteLine("Autor:" + _autor);
    }

    public int DostępnaIlosc()
    {
        if (_dostepnosc)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public double AktualnaCena()
    {
        return _cena;
    }

    public string Opis()
    {
        return _opis;
    }

}

public class Elektronika : Produkt
{
    protected string _urzadzenie;

    public Elektronika(string opis, double cena, bool dostępność, string urzadzenie)
        : base(opis, cena, dostępność)
    {
        _urzadzenie = urzadzenie;
    }

    public override void WyświetlInfo()
    {
        base.WyświetlInfo();
        Console.WriteLine("Urzadzenie:" + _urzadzenie);
    }

    public int DostępnaIlosc()
    {
        if (_dostepnosc)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public double AktualnaCena()
    {
        return _cena;
    }

    public string Opis()
    {
        return _opis;
    }

}

public class Odziez : Produkt
{
    protected string _ubranie;


    public Odziez(string opis, double cena, bool dostępność, string ubranie)
        : base(opis, cena, dostępność)
    {
        _ubranie = ubranie;
    }

    public override void WyświetlInfo()
    {
        base.WyświetlInfo();
        Console.WriteLine("Ubranie:" + _ubranie);

    }

    public int DostępnaIlosc()
    {
        if (_dostepnosc)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }


    public double AktualnaCena()
    {
        return _cena;
    }
    public string Opis()
    {
        return _opis;
    }


}

public abstract class Osoba
{
    protected string _imie;
    protected string _nazwisko;

    public Osoba(string imie, string nazwisko)
    {
        _imie = imie;
        _nazwisko = nazwisko;
    }
}


class Klient : Osoba
{
    private List<IProdukt> _koszyk;

    public Klient(string imie, string nazwisko)
        : base(imie, nazwisko)
    {
        _koszyk = new List<IProdukt>();
    }


    public void DodajDoKoszyka(IProdukt produkt)
    {
        if (produkt.DostępnaIlosc() > 0)
        {
            _koszyk.Add(produkt);
        }


    }

    public void WyswietlCene(IProdukt produkt)
    {
        Console.WriteLine("Cena produktu: " + produkt.AktualnaCena());
    }


    public double CenaKoszyka()
    {
        double suma = 0;
        foreach (var produkt in _koszyk)
        {
            suma += produkt.AktualnaCena();
        }
        return suma;
    }
}