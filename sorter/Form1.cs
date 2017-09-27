using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using ExifLib;//libraria pentru extragere data din jpg mult mai rapid

namespace sorter
{
    public partial class form_principal : Form
    {
        form_extensions Extensions_form = new form_extensions() ;
        form_months Months_form = new form_months();
        string source_path;
        string destination_root;
        string[] month;
        string[] extensions;
        int nr_files=0;
        List <string> list_of_extensions= new List <string>();
        int number_of_files;
        int number_of_folders;
        int[, ,] count=new int[100,13,33]; //sir de frecventa pentru nume
        DateTime nodate = new DateTime(3000, 1, 1, 10, 10, 10);

        public form_principal()
        {
            InitializeComponent();
        }  
      

        private void button_source_Click(object sender, EventArgs e) //se selecteaza folderul sursa
        {
            folderBrowserDialog_source.ShowDialog();
            label_source.Text = folderBrowserDialog_source.SelectedPath;
            source_path = folderBrowserDialog_source.SelectedPath;
        }

        private void button_destination_Click(object sender, EventArgs e) //se selecteaza folderul destinatie
        {
            folderBrowserDialog_destination.ShowDialog();
            label_destinatie.Text = folderBrowserDialog_destination.SelectedPath;
            destination_root = folderBrowserDialog_destination.SelectedPath;
        }

        private void monthsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Months_form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) //butonul de start
        {
        
            if (folderBrowserDialog_source.SelectedPath == "")
            {
                MessageBox.Show("Please select a source first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);//nu e selectat folder sursa
                return;
            }
            if (folderBrowserDialog_destination.SelectedPath == "" && (checkBox_copiere.Checked || checkBox_move.Checked)) 
            { 
                MessageBox.Show("Please select a destination first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); //nu e selectata destinatie
                return;
            }

            for (int i = 0; i <= 99; ++i)     //se initializeaza contorul pentru nume
                for (int j = 0; j <= 12; ++j)
                    for (int z = 0; z <= 32; ++z) count[i, j, z] = 1;
                        number_of_files = number_of_folders = 0;

            extensions = Extensions_form.extensions.Lines;
            month = new string[13];

            foreach (Control c in Months_form.Controls) //stabilesti numele lunilor
            {
                if ((c is TextBox) && (c.Name!="unsorted_textbox"))
                {
                    string s = c.Name;
                    s = s.Substring(s.Length - 2);
                    month[Convert.ToInt32(s)] = c.Text;
                }
            }

            number_of_files = 0;
            number_of_folders = 0;

            process_folder(source_path); //apelezi metoda in care manipulezi fisierele
            Console.WriteLine("FINISH");
            Console.WriteLine(number_of_folders + " folders and " + number_of_files + " files");
            checkBox_copiere.Checked = checkBox_move.Checked = false;
        }

        private void process_folder(string path) //metoda in care manipulezi fisierele
        {
            if (path == destination_root) return;//cazu in care vreau sa iau si sa pun pozele in acelasi folder
            
            string[] files = {};
            ++number_of_folders;

            if (checkBox_list_files.Checked) Console.WriteLine("folder " + path); //afisez folderul curent

            string filename;
            DateTime date;

            foreach (string s in extensions) //pun toate fisierele cu extensia buna in files
            {
                try
                {
                    files = files.Concat(Directory.GetFiles(path, "*." + s)).ToArray();
                }
                catch { ;}
            }
            foreach (string s in files)
            {
                date = date_from_photo(s); //extragi data
                
                ++number_of_files;

                if (date == nodate) //cazu in care ii extensie la care inca nu e implementata data sau fisiere fara data
                {
                    if (checkBox_move.Checked) move_to_folder_unsorted(s);//te ocupi de fisier
                    else
                        if (checkBox_copiere.Checked) copy_to_folder_unsorted(s);
                        else
                            if (checkBox_list_files.Checked) Console.WriteLine("\t"+s); //afisiezi fisierul
                }
                else
                {
                    filename = date.Day + " " + month[date.Month].ToLower() + " " + date.Year; //numele nou al fisierului
                    
                    if (checkBox_move.Checked) move_to_folder(s, filename, date); //te ocupi de fisier
                    else
                    if (checkBox_copiere.Checked) copy_to_folder(s, filename, date);
                    else if (checkBox_list_files.Checked) Console.WriteLine("\t" + s);
                }
              
                
            }

            string[] folders = {};
            try 
            {
                folders=Directory.GetDirectories(path);
            }
            catch {;}

            foreach (string s in folders) //intri recursiv in restul folderelor
                {
                   if(checkBox_subfolders.Checked) process_folder(s);
                }
        }

        private void repair_names_process_folder(string path) //redenumerotezi fisierele (ai sters vre-un fisier)
        {
            string[] files = { }; //iei fisierele din folder
            try
            {
                files = files.Concat(Directory.GetFiles(path, "*.*")).ToArray();
            }
            catch { ;}

            foreach (string s in files) 
            {
                string filename="";
                string folder = Path.GetDirectoryName(s);
                int nr = 0 ;
                get_file_name_and_number(s,ref filename,ref nr); //faci rost de numele si numarul vechi
               // Console.WriteLine(s+ "&&&"+ filename+ " "+ Convert.ToString(nr));
                --nr;
                while ( (!(File.Exists(Path.Combine(folder,filename + " - " + nr + Path.GetExtension(s))))) && (nr>0)) --nr; //gasesti numarul ce trebe sa il pui la sfarsit
                ++nr;
                //Console.WriteLine(s + "&&&" + filename + " " + Convert.ToString(nr));
               try
                {
                    File.Move(s, Path.Combine(folder, filename + " - " + nr + Path.GetExtension(s))); //practic ii rename
                    ++nr_files;
                    Console.WriteLine("repaired " +Path.Combine(folder, filename + " - " + nr + Path.GetExtension(s)));
                }
                catch { ;}
                
            }

            string[] folders = { };
            try         
            {
                folders = Directory.GetDirectories(path);
            }
            catch { ;}
            foreach (string s in folders) //mergi si in subfoldere
            {
                if (checkBox_subfolders.Checked) repair_names_process_folder(s);
            }
        }

        private void get_file_name_and_number(string s,ref string name,ref int nr) //in name pui numele vechi si in nr indicele vechi
    {
        string local = Path.GetFileNameWithoutExtension(s);
        int pos = local.LastIndexOf("-");          //asta ii separatoru
        nr = Convert.ToInt32(local.Substring(pos + 2));

        //verifici sa chiar existe - in nume
        if(pos>0) name=local.Remove(pos - 1);
        
    }

        private void move_to_folder_unsorted(string source_file) //muta fisierele fara data
        {
            string dest_path = get_path_to_unsorted_folder(source_file); //se creeaza subdirectoarele

            int i = 1;
            string filename = Path.GetFileNameWithoutExtension(source_file);
            while (File.Exists(Path.Combine(dest_path, filename + " - " + i + Path.GetExtension(source_file)))) ++i;
            filename = filename + " - " + i + Path.GetExtension(source_file);

            try
            {
                File.Move(source_file, Path.Combine(dest_path, filename));
                if (checkBox_list_files.Checked) Console.WriteLine("\tmoved " + source_file);
            }
            catch
            {
                Console.WriteLine("not moved");
            }

        }

        private void copy_to_folder_unsorted(string source_file)//copiaza fisierele fara data
        {
            string dest_path = get_path_to_unsorted_folder(source_file);//se creeaza subdirectoarele
            
            int i=1;
            string filename=Path.GetFileNameWithoutExtension(source_file);
            while (File.Exists(Path.Combine(dest_path, filename + " - " + i + Path.GetExtension(source_file)))) ++i;
            filename = filename + " - " + i + Path.GetExtension(source_file);
            
            try
            {
                File.Copy(source_file, Path.Combine(dest_path, filename));
                if (checkBox_list_files.Checked) Console.WriteLine("\tcopied " + source_file);
            }
            catch
            {
                Console.WriteLine("not copied") ;
            }

        }

        private void move_to_folder(string source_file, string filename, DateTime date)//muta fisierele cu data
        {
            string dest_path = get_path_to_folder(date);
            while (File.Exists(Path.Combine(dest_path, filename + " - " + count[date.Year % 100, date.Month, date.Day] + Path.GetExtension(source_file)))) ++count[date.Year % 100, date.Month, date.Day];
            filename = filename + " - " + count[date.Year % 100, date.Month, date.Day];
            File.Move(source_file, Path.Combine(dest_path, filename + Path.GetExtension(source_file)));
            if (checkBox_list_files.Checked) Console.WriteLine("\tmoved " + source_file);
        }

        private void copy_to_folder(string source_file,string filename,DateTime date)
        {
            string dest_path=get_path_to_folder(date);
            while (File.Exists(Path.Combine(dest_path, filename + " - " + count[date.Year % 100, date.Month, date.Day]+ Path.GetExtension(source_file)))) ++count[date.Year % 100, date.Month, date.Day];
            filename = filename + " - " + count[date.Year % 100, date.Month, date.Day];
            File.Copy(source_file, Path.Combine(dest_path, filename+ Path.GetExtension(source_file)));
            if (checkBox_list_files.Checked) Console.WriteLine("\tcopied " + source_file);
        }

        private string get_path_to_unsorted_folder(string source_file) //metoda creeaza structura de foldere pentru o extensie
        {
            string extension = Path.GetExtension(source_file);
            string s = " " + Months_form.unsorted_textbox.Text;
            if (!Directory.Exists(Path.Combine(destination_root,extension+s))) Directory.CreateDirectory(Path.Combine(destination_root,extension+s));
            return Path.Combine(destination_root,extension+s);
        }


        private string get_path_to_folder(DateTime date) //metoda creeaza structura de foldere pentru o data
        {
            if (Directory.Exists(Path.Combine(destination_root, Convert.ToString(date.Year))))
            {
                if (Directory.Exists(Path.Combine(destination_root, Convert.ToString(date.Year), month[date.Month])))
                {
                    return Path.Combine(destination_root, Convert.ToString(date.Year), month[date.Month]);
                }
                else
                {
                    Directory.CreateDirectory(Path.Combine(destination_root, Convert.ToString(date.Year), month[date.Month]));
                    return get_path_to_folder(date);
                }
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(destination_root, Convert.ToString(date.Year)));
                return get_path_to_folder(date);
            }
        }
        private void extensionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Extensions_form.ShowDialog();
        }

        private void get_paths_button_Click(object sender, EventArgs e) //butonul pentru afisarea extensiilor
        {
            list_of_extensions.Clear();
            get_folder_extensions(folderBrowserDialog_source.SelectedPath); //gasesti extensiile
            foreach (string s in list_of_extensions)
            Console.WriteLine(s);
            Console.WriteLine("Finish");
        }

        private void get_folder_extensions(string path)  //metoda in care gasesti extensiile
        {
            if (path == destination_root) return;//cazu in care foldetul curent e si destinatia

            string[] files={ };
            try
            {
                files = Directory.GetFiles(path);
            }
            catch { ;}

            foreach (string s in files)
            {
               if (!list_of_extensions.Exists(x => x==Path.GetExtension(s))) list_of_extensions.Add(Path.GetExtension(s)); //adaugi extensii noi
            }

            string[] folders = { }; 
            try
            {
                folders = Directory.GetDirectories(path);
            }
            catch { ;}
            foreach (string s in folders) //mergi in subfoldere
            {
                if (checkBox_subfolders.Checked) get_folder_extensions(s);
            }

        }

        private DateTime date_from_photo(string s)
        {

            DateTime datePictureTaken = nodate; //initializezi cu nodate


            try //extragi data, merge momentan numa pentru jpg
            {
                using (ExifReader reader = new ExifReader(s))
                {
                    // Extract the tag data using the ExifTags enumeration

                    if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datePictureTaken))
                    {

                    }
                }
            }
            catch { ;}

            //in aceasta functie se mai poate implementa extragerea datei si pentru alte extensii

            return datePictureTaken;
        }

        private void checkBox_move_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_move.Checked && checkBox_copiere.Checked)
            {
                MessageBox.Show("You can not copy and move files","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                checkBox_copiere.Checked = false;
            }
        }

        private void checkBox_copiere_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_move.Checked && checkBox_copiere.Checked)
            {
                MessageBox.Show("You can not copy and move files", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox_move.Checked = false;
            }
        }

        private void button_repair_file_names_Click(object sender, EventArgs e) //butonul de reparat numele
        {
            nr_files = 0;

            repair_names_process_folder(folderBrowserDialog_destination.SelectedPath);
            Console.WriteLine("FINISH " + nr_files+" files");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //afisezi informatii despre aplicatie
        {
            MessageBox.Show("developed by Vasile Lup\nsorter v1.0","About",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        
    }
     
      
}
