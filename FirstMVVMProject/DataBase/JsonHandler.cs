
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;


namespace FirstMVVMProject.DataBase;

    public class JsonHandler<T>
    {

        public string Path { get; set; }
        public ObservableCollection<T> Items { get; set; }
        public JsonHandler(string path)
        {

            Path = path;
            if (File.Exists(path))
            {
                string JSON = File.ReadAllText(path);
                Items = JsonSerializer.Deserialize<ObservableCollection<T>>(JSON);

            }
            else Items=new();
        }

        public void SaveData()
        {
            var a = JsonSerializer.Serialize(Items);
            File.WriteAllText(Path, a);
        }


    }

