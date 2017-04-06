using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace SkanSieciLokalnej_v3
{
    public partial class Form1 : Form
    {

        Thread thread1 = null;
        Thread thread2 = null;
        Thread thread3 = null;
        Thread thread4 = null;
        Thread thread5 = null;
        Thread thread6 = null;
        Thread thread7 = null;
        Thread thread8 = null;
        Thread thread9 = null;
        Thread thread10 = null;
        Thread glowny = null;

        static List<string> Lista_adresow = new List<string>();
        List<string> ListaPodsieci = new List<string>();
        string wybranapodsiec = String.Empty;
        string wybranapodsiec_trim = "192.168.1.";

        Skan skan1;
        Skan skan2;
        Skan skan3;
        Skan skan4;
        Skan skan5;
        Skan skan6;
        Skan skan7;
        Skan skan8;
        Skan skan9;
        Skan skan10;

        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 255;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Text = String.Empty;
            label2.Text = String.Empty;
            label3.Text = "192.168.1.1";
            label4.Text = String.Empty;
            button2.Enabled = false;
        }

        public void Przelacz_przycisk(Button button, bool value)
        {
            if (button.InvokeRequired)
            {
                button.Invoke((MethodInvoker)delegate ()
                {
                    Przelacz_przycisk(button, value);
                });
            }
            else
            {
                button.Enabled = value;
            }
        }

        public void ProgressUpdate(ProgressBar progressbar, int value)
        {
            if (progressbar.InvokeRequired)
            {
                progressbar.Invoke((MethodInvoker)delegate ()
                {
                    ProgressUpdate(progressbar, value);
                });
            }
            else
            {
                if (value > 255)
                {
                    value = 255;
                }
                progressbar.Value = value;
            }
        }

        public void wypisztekstLabel(Label label, string tekst)
        {
            if (label.InvokeRequired)
            {
                label.Invoke((MethodInvoker)delegate ()
                {
                    wypisztekstLabel(label, tekst);
                });
            }
            else
            {
                label.Text = tekst;
            }
        }

        public void wypisztekstLisBox(ListBox listbox, string tekst)
        {
            if (listbox.InvokeRequired)
            {
                listbox.Invoke((MethodInvoker)delegate ()
                {
                    wypisztekstLisBox(listbox, tekst);
                });
            }
            else
            {
                listbox.Items.Add(tekst);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            skan1 = new Skan();
            skan2 = new Skan();
            skan3 = new Skan();
            skan4 = new Skan();
            skan5 = new Skan();
            skan6 = new Skan();
            skan7 = new Skan();
            skan8 = new Skan();
            skan9 = new Skan();
            skan10 = new Skan();

            Lista_adresow.Clear();
            label2.Text = "Pracuje...";
            label4.Text = String.Empty;
            listBox1.Items.Clear();

            skan1.Stop = false;
            skan2.Stop = false;
            skan3.Stop = false;
            skan4.Stop = false;
            skan5.Stop = false;
            skan6.Stop = false;
            skan7.Stop = false;
            skan8.Stop = false;
            skan9.Stop = false;
            skan10.Stop = false;

            skan1.Adres_sieci = wybranapodsiec_trim;
            skan2.Adres_sieci = wybranapodsiec_trim;
            skan3.Adres_sieci = wybranapodsiec_trim;
            skan4.Adres_sieci = wybranapodsiec_trim;
            skan5.Adres_sieci = wybranapodsiec_trim;
            skan6.Adres_sieci = wybranapodsiec_trim;
            skan7.Adres_sieci = wybranapodsiec_trim;
            skan8.Adres_sieci = wybranapodsiec_trim;
            skan9.Adres_sieci = wybranapodsiec_trim;
            skan10.Adres_sieci = wybranapodsiec_trim;

            skan1.Ustaw_zakres(0,24);
            skan2.Ustaw_zakres(25, 49);
            skan3.Ustaw_zakres(50, 74);
            skan4.Ustaw_zakres(75, 99);
            skan5.Ustaw_zakres(100, 124);
            skan6.Ustaw_zakres(125, 149);
            skan7.Ustaw_zakres(150, 174);
            skan8.Ustaw_zakres(175, 199);
            skan9.Ustaw_zakres(200, 224);
            skan10.Ustaw_zakres(225, 255);

            thread1 = new Thread(new ThreadStart(skan1.skan));
            thread2 = new Thread(new ThreadStart(skan2.skan));
            thread3 = new Thread(new ThreadStart(skan3.skan));
            thread4 = new Thread(new ThreadStart(skan4.skan));
            thread5 = new Thread(new ThreadStart(skan5.skan));
            thread6 = new Thread(new ThreadStart(skan6.skan));
            thread7 = new Thread(new ThreadStart(skan7.skan));
            thread8 = new Thread(new ThreadStart(skan8.skan));
            thread9 = new Thread(new ThreadStart(skan9.skan));
            thread10 = new Thread(new ThreadStart(skan10.skan));

            thread1.Start();                        
            thread2.Start();                        
            thread3.Start();                      
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();
            thread9.Start();
            thread10.Start();

            glowny = new Thread(new ThreadStart(obsuga));
            glowny.Start();

            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
        }

        public void obsuga()
        {
            int postep = 0;
            bool koncz1 = false;
            bool koncz2 = false;
            bool koncz3 = false;
            bool koncz4 = false;
            bool koncz5 = false;
            bool koncz6 = false;
            bool koncz7 = false;
            bool koncz8 = false;
            bool koncz9 = false;
            bool koncz10 = false;
            do
            {
                if (skan1.Czy_koniec == true && koncz1 == false)
                {
                    Lista_adresow.AddRange(skan1.ZnalezioneAdresy);
                    koncz1 = true;
                }

                if (skan2.Czy_koniec == true && koncz2 == false)
                {
                    Lista_adresow.AddRange(skan2.ZnalezioneAdresy);
                    koncz2 = true;
                }

                if (skan3.Czy_koniec == true && koncz3 == false)
                {
                    Lista_adresow.AddRange(skan3.ZnalezioneAdresy);
                    koncz3 = true;
                }

                if (skan4.Czy_koniec == true && koncz4 == false)
                {
                    Lista_adresow.AddRange(skan4.ZnalezioneAdresy);
                    koncz4 = true;
                }

                if (skan5.Czy_koniec == true && koncz5 == false)
                {
                    Lista_adresow.AddRange(skan5.ZnalezioneAdresy);;
                    koncz5 = true;
                }

                if (skan6.Czy_koniec == true && koncz6 == false)
                {
                    Lista_adresow.AddRange(skan6.ZnalezioneAdresy); ;
                    koncz6 = true;
                }

                if (skan7.Czy_koniec == true && koncz7 == false)
                {
                    Lista_adresow.AddRange(skan7.ZnalezioneAdresy); ;
                    koncz7 = true;
                }

                if (skan8.Czy_koniec == true && koncz8 == false)
                {
                    Lista_adresow.AddRange(skan8.ZnalezioneAdresy); ;
                    koncz8 = true;
                }

                if (skan9.Czy_koniec == true && koncz9 == false)
                {
                    Lista_adresow.AddRange(skan9.ZnalezioneAdresy); ;
                    koncz9 = true;
                }

                if (skan10.Czy_koniec == true && koncz10 == false)
                {
                    Lista_adresow.AddRange(skan10.ZnalezioneAdresy); ;
                    koncz10 = true;
                }

                postep = skan1.J + skan2.J + skan3.J + skan4.J + skan5.J + skan6.J + skan7.J + skan8.J + skan9.J + skan10.J;

                if (postep > 255)
                {
                    postep = 255;
                }

                wypisztekstLabel(label1, wybranapodsiec_trim + postep);
                ProgressUpdate(progressBar1, postep);

                Thread.Sleep(100);
            } while (postep < 255 || koncz1 == false || koncz2 == false || koncz3 == false || koncz4 == false || koncz5 == false || koncz6 == false || koncz7 == false || koncz8 == false || koncz9 == false || koncz10 == false);

            if (postep >= 255)
            {
                Przelacz_przycisk(button1, true);
                Przelacz_przycisk(button2, false);
                Przelacz_przycisk(button3, true);
                wypisztekstLabel(label2, "Zakończone");
                for (int i = 0; i < Lista_adresow.Count; i++)
                {
                    wypisztekstLisBox(listBox1, Lista_adresow[i]);
                    wypisztekstLabel(label4, "Licz. urządzeń: "+Lista_adresow.Count.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (thread1.IsAlive)
            {
                skan1.Stop = true;
                thread1.Suspend();
                label2.Text = "Zatrzymano";               
            }
            if (thread2.IsAlive)
            {
                skan2.Stop = true;
                thread2.Suspend(); ;
                label2.Text = "Zatrzymano";                
            }

            if (thread3.IsAlive)
            {
                skan3.Stop = true;
                thread3.Suspend();
                label2.Text = "Zatrzymano";                
            }

            if (thread4.IsAlive)
            {
                skan4.Stop = true;
                thread4.Suspend();
                label2.Text = "Zatrzymano";               
            }

            if (thread5.IsAlive)
            {
                skan5.Stop = true;
                thread5.Suspend();
                label2.Text = "Zatrzymano";                
            }

            if (thread6.IsAlive)
            {
                skan6.Stop = true;
                thread6.Suspend();
                label2.Text = "Zatrzymano";
            }

            if (thread7.IsAlive)
            {
                skan7.Stop = true;
                thread7.Suspend();
                label2.Text = "Zatrzymano";
            }

            if (thread8.IsAlive)
            {
                skan8.Stop = true;
                thread8.Suspend();
                label2.Text = "Zatrzymano";
            }

            if (thread8.IsAlive)
            {
                skan8.Stop = true;
                thread8.Suspend();
                label2.Text = "Zatrzymano";
            }

            if (thread9.IsAlive)
            {
                skan9.Stop = true;
                thread9.Suspend();
                label2.Text = "Zatrzymano";
            }

            if (thread10.IsAlive)
            {
                skan10.Stop = true;
                thread10.Suspend();
                label2.Text = "Zatrzymano";
            }

            if (glowny.IsAlive)
            {
                glowny.Abort();
                label2.Text = "Zatrzymano";
            }
            ProgressUpdate(progressBar1, 0);
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaPodsieci.Clear();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ListaPodsieci.Add(ip.ToString());
                }
            }
            Wybor_sieci wybierz = new Wybor_sieci();
            wybierz.Wybierz_siec(ListaPodsieci);
            wybierz.ShowDialog();
            wybranapodsiec = wybierz.Wybrana_siec;
            label3.Text = wybranapodsiec;

            string[] temp = wybranapodsiec.Split('.');
            wybranapodsiec_trim = temp[0] + "." + temp[1] + "." + temp[2] + ".";
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

        
    }

    public class Skan
    {
        List<string> znalezione_adresy = new List<string>();

        int zakres = 0;
        string adres_sieci = "192.168.1.";
        int j = 0, zakres_od = 0, zakres_do = 25;
        bool stop = false;
        bool czy_koniec = false;

        public void Ustaw_zakres(int z_od, int z_do)
        {
            zakres_od = z_od;
            zakres_do = z_do;
        }
        public int J
        {
            get
            {
                return j;
            }
        }
        public List<string> ZnalezioneAdresy
        {
            get
            {
                return znalezione_adresy;
            }
        }
        public bool Czy_koniec
        {
            get
            {
                return czy_koniec;
            }

            set
            {
                czy_koniec = value;
            }
        }
        public int Zakres
        {
            get
            {
                return zakres;
            }

            set
            {
                zakres = value;
            }
        }
        public bool Stop
        {
            set
            {
                stop = value;
            }
        }
        public string Adres_sieci
        {
            set
            {
                adres_sieci = value;
            }
        }

        public void skan()
        {
            znalezione_adresy.Clear();
            Ping ping;
            PingReply reply;
            IPAddress address;
            IPHostEntry host;

            for (int i = zakres_od; i <= zakres_do; i++)
            {
                if (stop == true)
                {
                    j = 0;
                    znalezione_adresy.Clear();
                    break;
                }
                
                ping = new Ping();
                try
                {
                    reply = ping.Send(adres_sieci + i.ToString(), 900);
                    if (reply.Status == IPStatus.Success)
                    {
                        try
                        {
                            address = IPAddress.Parse(adres_sieci + i.ToString());
                            host = Dns.GetHostEntry(address);
                            znalezione_adresy.Add(adres_sieci + i.ToString() + " " + host.HostName.ToString());
                        }
                        catch (Exception)
                        {
                            znalezione_adresy.Add(adres_sieci + i.ToString());
                        }
                    }
                }
                catch (Exception) { }
                j++;                              
            }
            czy_koniec = true;
        }
    }
}
