using System.Threading.Channels;


class Program 
{
    static void Main(string[] args)
    {   
        //test aja
        //a. Kelas Hewan dengan properti nama dan umur
        Hewan hewan1 = new Hewan("Kucing",2 );
        Console.WriteLine(hewan1.nama + " berumur " + hewan1.umur + " tahun" );

        //b. Kelas Mamalia yang mewarisi Hewan, dengan properti tambahan jumlahKaki
        Mamalia mamalia1 = new Mamalia("Sapi", 2, 4);
        Console.WriteLine(mamalia1.nama + " berumur " + mamalia1.umur + " tahun dengan jumlah kakinya " + mamalia1.jumlahKaki);

        //c. Kelas Reptil 
        Reptil reptil1 = new Reptil("Komodo", 2, 3);
        Console.WriteLine(reptil1.nama + " berumur " + reptil1.umur + " tahun dan memiliki panjang tubuh " + reptil1.panjangTubuh + " meter \n");

        //-------------------------------------------------------


        //implementasi objek buaya di reptil
        Reptil reptilBaru = new Reptil("Buaya D", 4, 10);
        Console.WriteLine(reptilBaru.Bersuara("bersuara"));

        //daftar hewan
        Singa singa1 = new Singa("Singa A", 12, 4, "Jinak");
        Console.WriteLine(singa1.nama + "| umur: " + singa1.umur + "| berkaki "+ singa1.jumlahKaki); //menampilkan informasi singa
        Gajah gajah1 = new Gajah("Gajah B", 5, 4, 3);
        Ular ular1 = new Ular("Ular C", 1, 23.6);
        Buaya buaya1 = new Buaya("Buaya D", 4, 10);

        //Menjalankan method dari objek yang telah dibuat diatas 
        ular1.Merayap();
        singa1.Mengaum();
        Console.WriteLine(ular1.Bersuara("desis"));
        Console.WriteLine(gajah1.Bersuara("bersuara\n"));


        //Objek kebun binatang
        KebunBinatang kebunBinatang1 = new KebunBinatang();

        kebunBinatang1.TambahHewan(singa1);
        kebunBinatang1.TambahHewan(gajah1);
        kebunBinatang1.TambahHewan(ular1);
        kebunBinatang1.TambahHewan(buaya1);

        kebunBinatang1.DaftarHewan();

    }
}
class Hewan
{
    public string nama;
    public int umur;

    public Hewan (string nama, int umur)
    {
        this.nama = nama;
        this.umur = umur;
    }

    // method diberi virtual sebab akan diwariskan dan merupakan superclass  
    public virtual string Bersuara(string suara)
    {
        return $"Hewan ini bersuara {suara}";
    }
    public virtual string InfoHewan()
    {
        return $"Nama: {nama}, Umur: {umur} tahun";
    }
}

//b.Kelas Mamalia yang mewarisi Hewan, dengan properti tambahan jumlahKaki
class Mamalia : Hewan
{
    public int jumlahKaki;

    public Mamalia (string nama, int umur, int jumlahKaki) : base (nama, umur)
    {
        
        this.jumlahKaki = jumlahKaki;
    }

    // method diberi override yang akan diwarisi dan merupakan subclass  
    public override string Bersuara(string suara)
    {
        base.Bersuara(suara);

        return $"Hewan itu bersuara dengan {suara}";
    }

}

//c.Kelas Reptil yang mewarisi Hewan, dengan properti tambahan panjangTubuh
class Reptil: Hewan
{
    public double panjangTubuh;

    public Reptil(string nama, int umur, double panjangTubuh): base (nama, umur)
    {
        this.panjangTubuh = panjangTubuh;
    }

    public override string Bersuara(string suara)
    {
        return "Reptil itu bersuara";
    }

}

//d.Kelas Singa yang mewarisi Mamalia
class Singa: Mamalia
{
    public string sifat;

    public Singa (string nama, int umur, int jumlahKaki, string sifat) : base (nama, umur, jumlahKaki)
    {
        this.sifat = sifat;
    }

    public void Mengaum()
    {
        Console.WriteLine($"{nama}, singa itu mengaum");
    }

    public override string Bersuara(string suara)
    {
        return $"Singa itu bersuara dengan keras";
    }
}

//d.Kelas Gajah yang mewarisi Mamalia
class Gajah : Mamalia
{
    public int Berat;

    public Gajah (string nama, int umur, int jumlahKaki, int Berat) : base(nama, umur, jumlahKaki)
    {
        this.Berat = Berat;
    }
    public void minum()
    {
        Console.WriteLine($"Gajah itu dengan {Berat} ton butuh air yang banyak");
    }
    public override string Bersuara(string suara)
    {
        base.Bersuara(suara);

        return $"Gajah ini {suara}";
    }
}

//e.Kelas Ular yang mewarisi Reptil
class Ular : Reptil
{
    public Ular (string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh)
    {

    }
    public void Merayap()
    {
        Console.WriteLine($"{nama}, ular itu melata");
    }
    public override string Bersuara(string suara)
    {
        base.Bersuara(suara);

        return $"Ular bersuara dengan {suara}";
    }
}

// e. Buaya yang mewarisi Reptil
class Buaya : Reptil
{
    public Buaya(string nama, int umur, double panjangTubuh) : base(nama, umur, panjangTubuh)
    {

    }
    public override string Bersuara(string suara)
    {
        base.Bersuara(suara);

        return $"Hewan itu bersuara dengan {suara}";
    }
}



//f.Kelas KebunBinatang yang memiliki koleksi Hewan
    class KebunBinatang
{
    public List<Hewan> koleksiHewan;

    public KebunBinatang()
    {
        koleksiHewan = new List<Hewan>();
    }

    public void TambahHewan(Hewan hewan)
    {
        koleksiHewan.Add(hewan);
        Console.WriteLine($"Hewan {hewan.nama} ditambahkan ke kebun binatang.");
    }

    public void DaftarHewan()
    {
        Console.WriteLine("\n Beberapa hewan yang menjadi koleksi di kebun binatang, yaitu:");
        foreach (var hewan in koleksiHewan) // iterasi cek informasi setiap elemen awal (hewan) dalam koleksi Hewan
        {
            Console.WriteLine($"- {hewan.nama} (Umur: {hewan.umur} tahun)");
        }
    }
}

