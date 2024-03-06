using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Konyvek
{
    public partial class Form1 : Form
    {
        List<Books> books_list = new List<Books>();
        public Form1()
        {
            InitializeComponent();
            string[] lines = File.ReadAllLines("books.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(',');
                Books books_object = new Books(values[0], values[1], values[2], values[3], values[4]);
                books_list.Add(books_object);
            }
            //2.Feladat
            int osszdb = 0;
            foreach (var item in books_list)
            {

                osszdb += item.db;


            }
            label1.Text = ($"Az össz darabszám: {osszdb} db");

            Console.WriteLine("6.Feladat");
            foreach (var book in books_list)
            {
                if (book.kategoria.Equals("Regény"))
                {

                    Console.WriteLine($"A regény kategóriában lévő könyv címe és ára: {book.kategoria},  {book.konyv}, {book.ar} ");
                }
            }

            Console.WriteLine("8.Feladat");
            List<Books> legdragabbak = new List<Books>(); // Listát használunk az összes legolcsóbb termék tárolásához
            Books legdragabb = books_list[0];
            legdragabbak.Add(legdragabb); // Az első terméket hozzáadjuk a listához

            foreach (var termek in books_list)
            {
                if (termek.ar > legdragabb.ar)
                {
                    // Ha a jelenlegi termék ára kisebb, akkor ő lesz az egyik legolcsóbb
                    legdragabb = termek;
                    legdragabbak.Clear(); // Töröljük a korábbi legolcsóbbakat, mert van újabb
                    legdragabbak.Add(legdragabb);
                }
                else if (termek.ar == legdragabb.ar)
                {
                    // Ha a jelenlegi termék ára megegyezik a legolcsóbb árával, akkor hozzáadjuk a listához
                    legdragabbak.Add(termek);
                }
            }

            Console.WriteLine("\nLegolcsóbb termek(ek) adatai:");
            foreach (var legdragabbTermek in legdragabbak)
            {
                dataGridView1.Rows.Add(legdragabbTermek.kategoria, legdragabbTermek.konyv, legdragabbTermek.ar);
            }


        }

        private void ok_Click(object sender, EventArgs e)
        {
            string selectedCategory = comboBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedCategory))
            {
                // Kategóriába tartozó termékek lekérése
                var selectedProducts = books_list.Where(t => t.kategoria.Equals(selectedCategory)).ToList();

                // Az eredmények megjelenítése (például ListBox-ban)
                listBox1.Items.Clear(); // Törölje a korábbi elemeket

                foreach (var termek in selectedProducts)
                {
                    listBox1.Items.Add($"Cím: {termek.konyv}, Ár: {termek.ar}, Darabszám: {termek.db}");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}