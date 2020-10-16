using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YakaHack
{
    public partial class Plugin : Form
    {
        string JSON = "";
        public Plugin(string JSONTemp)
        {
            InitializeComponent();
            JSON = JSONTemp;
        }

        private void Plugin_Load(object sender, EventArgs e)
        {
            dynamic JSONParse = JObject.Parse(JSON);
            int W = Int32.Parse(JSONParse.WindowSize.Width.ToString());
            int H = Int32.Parse(JSONParse.WindowSize.Height.ToString());
            this.Size = new System.Drawing.Size(W, H);
            this.Text = JSONParse.WindowTitle.ToString();
            string json = @"{
'Text': 'Hello'
}";
            int ButtonAmount = 0;
            dynamic dynJson = JsonConvert.DeserializeObject(JSON);
            foreach (var obj in dynJson.Buttons)
            {
                ButtonAmount++;
            }


            foreach (var i in Enumerable.Range(1, ButtonAmount))
            {
                string ButtonText = "";
                string h = "";
                string w = "";
                switch (i)
                {

                    case 1:
                        ButtonText = JSONParse.Buttons.Button1.Text;
                        h = JSONParse.Buttons.Button1.Height.ToString();
                        w = JSONParse.Buttons.Button1.Width.ToString();
                        break;
                    case 2:
                        ButtonText = JSONParse.Buttons.Button2.Text;
                        h = JSONParse.Buttons.Button2.Height.ToString();
                        w = JSONParse.Buttons.Button2.Width.ToString();
                        break;
                    case 3:
                        ButtonText = JSONParse.Buttons.Button3.Text;
                        h = JSONParse.Buttons.Button3.Height.ToString();
                        w = JSONParse.Buttons.Button3.Width.ToString();
                        break;
                    case 4:
                        ButtonText = JSONParse.Buttons.Button4.Text;
                        h = JSONParse.Buttons.Button4.Height.ToString();
                        w = JSONParse.Buttons.Button4.Width.ToString();
                        break;
                    case 5:
                        ButtonText = JSONParse.Buttons.Button5.Text;
                        h = JSONParse.Buttons.Button5.Height.ToString();
                        w = JSONParse.Buttons.Button5.Width.ToString();
                        break;
                    case 6:
                        ButtonText = JSONParse.Buttons.Button6.Text;
                        h = JSONParse.Buttons.Button6.Height.ToString();
                        w = JSONParse.Buttons.Button6.Width.ToString();
                        break;
                    case 7:
                        ButtonText = JSONParse.Buttons.Button7.Text;
                        h = JSONParse.Buttons.Button7.Height.ToString();
                        w = JSONParse.Buttons.Button7.Width.ToString();
                        break;
                    case 8:
                        ButtonText = JSONParse.Buttons.Button8.Text;
                        h = JSONParse.Buttons.Button8.Height.ToString();
                        w = JSONParse.Buttons.Button8.Width.ToString();
                        break;
                    case 9:
                        ButtonText = JSONParse.Buttons.Button9.Text;
                        h = JSONParse.Buttons.Button9.Height.ToString();
                        w = JSONParse.Buttons.Button9.Width.ToString();
                        break;
                    case 10:
                        ButtonText = JSONParse.Buttons.Button10.Text;
                        h = JSONParse.Buttons.Button10.Height.ToString();
                        w = JSONParse.Buttons.Button10.Width.ToString();
                        break;
                    case 11:
                        ButtonText = JSONParse.Buttons.Button11.Text;
                        h = JSONParse.Buttons.Button11.Height.ToString();
                        w = JSONParse.Buttons.Button11.Width.ToString();
                        break;
                    case 12:
                        ButtonText = JSONParse.Buttons.Button12.Text;
                        h = JSONParse.Buttons.Button12.Height.ToString();
                        w = JSONParse.Buttons.Button12.Width.ToString();
                        break;
                    case 13:
                        ButtonText = JSONParse.Buttons.Button13.Text;
                        h = JSONParse.Buttons.Button13.Height.ToString();
                        w = JSONParse.Buttons.Button13.Width.ToString();
                        break;
                    case 14:
                        ButtonText = JSONParse.Buttons.Button14.Text;
                        h = JSONParse.Buttons.Button14.Height.ToString();
                        w = JSONParse.Buttons.Button14.Width.ToString();
                        break;
                    case 15:
                        ButtonText = JSONParse.Buttons.Button15.Text;
                        h = JSONParse.Buttons.Button15.Height.ToString();
                        w = JSONParse.Buttons.Button15.Width.ToString();
                        break;
                    case 16:
                        ButtonText = JSONParse.Buttons.Button16.Text;
                        h = JSONParse.Buttons.Button16.Height.ToString();
                        w = JSONParse.Buttons.Button16.Width.ToString();
                        break;
                    case 17:
                        ButtonText = JSONParse.Buttons.Button17.Text;
                        h = JSONParse.Buttons.Button17.Height.ToString();
                        w = JSONParse.Buttons.Button17.Width.ToString();
                        break;
                    case 18:
                        ButtonText = JSONParse.Buttons.Button18.Text;
                        h = JSONParse.Buttons.Button18.Height.ToString();
                        w = JSONParse.Buttons.Button18.Width.ToString();
                        break;
                    case 19:
                        ButtonText = JSONParse.Buttons.Button19.Text;
                        h = JSONParse.Buttons.Button19.Height.ToString();
                        w = JSONParse.Buttons.Button19.Width.ToString();
                        break;
                    case 20:
                        ButtonText = JSONParse.Buttons.Button20.Text;
                        h = JSONParse.Buttons.Button20.Height.ToString();
                        w = JSONParse.Buttons.Button20.Width.ToString();
                        break;
                    case 21:
                        ButtonText = JSONParse.Buttons.Button21.Text;
                        h = JSONParse.Buttons.Button21.Height.ToString();
                        w = JSONParse.Buttons.Button21.Width.ToString();
                        break;
                    case 22:
                        ButtonText = JSONParse.Buttons.Button22.Text;
                        h = JSONParse.Buttons.Button22.Height.ToString();
                        w = JSONParse.Buttons.Button22.Width.ToString();
                        break;
                    case 23:
                        ButtonText = JSONParse.Buttons.Button23.Text;
                        h = JSONParse.Buttons.Button23.Height.ToString();
                        w = JSONParse.Buttons.Button23.Width.ToString();
                        break;
                    case 24:
                        ButtonText = JSONParse.Buttons.Button24.Text;
                        h = JSONParse.Buttons.Button24.Height.ToString();
                        w = JSONParse.Buttons.Button24.Width.ToString();
                        break;
                    case 25:
                        ButtonText = JSONParse.Buttons.Button25.Text;
                        h = JSONParse.Buttons.Button25.Height.ToString();
                        w = JSONParse.Buttons.Button25.Width.ToString();
                        break;
                    case 26:
                        ButtonText = JSONParse.Buttons.Button26.Text;
                        h = JSONParse.Buttons.Button26.Height.ToString();
                        w = JSONParse.Buttons.Button26.Width.ToString();
                        break;
                    case 27:
                        ButtonText = JSONParse.Buttons.Button27.Text;
                        h = JSONParse.Buttons.Button27.Height.ToString();
                        w = JSONParse.Buttons.Button27.Width.ToString();
                        break;
                    case 28:
                        ButtonText = JSONParse.Buttons.Button28.Text;
                        h = JSONParse.Buttons.Button28.Height.ToString();
                        w = JSONParse.Buttons.Button28.Width.ToString();
                        break;
                    case 29:
                        ButtonText = JSONParse.Buttons.Button29.Text;
                        h = JSONParse.Buttons.Button29.Height.ToString();
                        w = JSONParse.Buttons.Button29.Width.ToString();
                        break;
                    case 30:
                        ButtonText = JSONParse.Buttons.Button30.Text;
                        h = JSONParse.Buttons.Button30.Height.ToString();
                        w = JSONParse.Buttons.Button30.Width.ToString();
                        break;
                    case 31:
                        ButtonText = JSONParse.Buttons.Button31.Text;
                        h = JSONParse.Buttons.Button31.Height.ToString();
                        w = JSONParse.Buttons.Button31.Width.ToString();
                        break;
                    case 32:
                        ButtonText = JSONParse.Buttons.Button32.Text;
                        h = JSONParse.Buttons.Button32.Height.ToString();
                        w = JSONParse.Buttons.Button32.Width.ToString();
                        break;
                    case 33:
                        ButtonText = JSONParse.Buttons.Button33.Text;
                        h = JSONParse.Buttons.Button33.Height.ToString();
                        w = JSONParse.Buttons.Button33.Width.ToString();
                        break;
                    case 34:
                        ButtonText = JSONParse.Buttons.Button34.Text;
                        h = JSONParse.Buttons.Button34.Height.ToString();
                        w = JSONParse.Buttons.Button34.Width.ToString();
                        break;
                    case 35:
                        ButtonText = JSONParse.Buttons.Button35.Text;
                        h = JSONParse.Buttons.Button35.Height.ToString();
                        w = JSONParse.Buttons.Button35.Width.ToString();
                        break;
                    case 36:
                        ButtonText = JSONParse.Buttons.Button36.Text;
                        h = JSONParse.Buttons.Button36.Height.ToString();
                        w = JSONParse.Buttons.Button36.Width.ToString();
                        break;
                    case 37:
                        ButtonText = JSONParse.Buttons.Button37.Text;
                        h = JSONParse.Buttons.Button37.Height.ToString();
                        w = JSONParse.Buttons.Button37.Width.ToString();
                        break;
                    case 38:
                        ButtonText = JSONParse.Buttons.Button38.Text;
                        h = JSONParse.Buttons.Button38.Height.ToString();
                        w = JSONParse.Buttons.Button38.Width.ToString();
                        break;
                    case 39:
                        ButtonText = JSONParse.Buttons.Button39.Text;
                        h = JSONParse.Buttons.Button39.Height.ToString();
                        w = JSONParse.Buttons.Button39.Width.ToString();
                        break;
                    case 40:
                        ButtonText = JSONParse.Buttons.Button40.Text;
                        h = JSONParse.Buttons.Button40.Height.ToString();
                        w = JSONParse.Buttons.Button40.Width.ToString();
                        break;
                    case 41:
                        ButtonText = JSONParse.Buttons.Button41.Text;
                        h = JSONParse.Buttons.Button41.Height.ToString();
                        w = JSONParse.Buttons.Button41.Width.ToString();
                        break;
                    case 42:
                        ButtonText = JSONParse.Buttons.Button42.Text;
                        h = JSONParse.Buttons.Button42.Height.ToString();
                        w = JSONParse.Buttons.Button42.Width.ToString();
                        break;
                    case 43:
                        ButtonText = JSONParse.Buttons.Button43.Text;
                        h = JSONParse.Buttons.Button43.Height.ToString();
                        w = JSONParse.Buttons.Button43.Width.ToString();
                        break;
                    case 44:
                        ButtonText = JSONParse.Buttons.Button44.Text;
                        h = JSONParse.Buttons.Button44.Height.ToString();
                        w = JSONParse.Buttons.Button44.Width.ToString();
                        break;
                    case 45:
                        ButtonText = JSONParse.Buttons.Button45.Text;
                        h = JSONParse.Buttons.Button45.Height.ToString();
                        w = JSONParse.Buttons.Button45.Width.ToString();
                        break;
                    case 46:
                        ButtonText = JSONParse.Buttons.Button46.Text;
                        h = JSONParse.Buttons.Button46.Height.ToString();
                        w = JSONParse.Buttons.Button46.Width.ToString();
                        break;
                    case 47:
                        ButtonText = JSONParse.Buttons.Button47.Text;
                        h = JSONParse.Buttons.Button47.Height.ToString();
                        w = JSONParse.Buttons.Button47.Width.ToString();
                        break;
                    case 48:
                        ButtonText = JSONParse.Buttons.Button48.Text;
                        h = JSONParse.Buttons.Button48.Height.ToString();
                        w = JSONParse.Buttons.Button48.Width.ToString();
                        break;
                    case 49:
                        ButtonText = JSONParse.Buttons.Button49.Text;
                        h = JSONParse.Buttons.Button49.Height.ToString();
                        w = JSONParse.Buttons.Button49.Width.ToString();
                        break;
                    case 50:
                        ButtonText = JSONParse.Buttons.Button50.Text;
                        h = JSONParse.Buttons.Button50.Height.ToString();
                        w = JSONParse.Buttons.Button50.Width.ToString();
                        break;
                    case 51:
                        ButtonText = JSONParse.Buttons.Button51.Text;
                        h = JSONParse.Buttons.Button51.Height.ToString();
                        w = JSONParse.Buttons.Button51.Width.ToString();
                        break;
                    case 52:
                        ButtonText = JSONParse.Buttons.Button52.Text;
                        h = JSONParse.Buttons.Button52.Height.ToString();
                        w = JSONParse.Buttons.Button52.Width.ToString();
                        break;
                    case 53:
                        ButtonText = JSONParse.Buttons.Button53.Text;
                        h = JSONParse.Buttons.Button53.Height.ToString();
                        w = JSONParse.Buttons.Button53.Width.ToString();
                        break;
                    case 54:
                        ButtonText = JSONParse.Buttons.Button54.Text;
                        h = JSONParse.Buttons.Button54.Height.ToString();
                        w = JSONParse.Buttons.Button54.Width.ToString();
                        break;
                    case 55:
                        ButtonText = JSONParse.Buttons.Button55.Text;
                        h = JSONParse.Buttons.Button55.Height.ToString();
                        w = JSONParse.Buttons.Button55.Width.ToString();
                        break;
                    case 56:
                        ButtonText = JSONParse.Buttons.Button56.Text;
                        h = JSONParse.Buttons.Button56.Height.ToString();
                        w = JSONParse.Buttons.Button56.Width.ToString();
                        break;
                    case 57:
                        ButtonText = JSONParse.Buttons.Button57.Text;
                        h = JSONParse.Buttons.Button57.Height.ToString();
                        w = JSONParse.Buttons.Button57.Width.ToString();
                        break;
                    case 58:
                        ButtonText = JSONParse.Buttons.Button58.Text;
                        h = JSONParse.Buttons.Button58.Height.ToString();
                        w = JSONParse.Buttons.Button58.Width.ToString();
                        break;
                    case 59:
                        ButtonText = JSONParse.Buttons.Button59.Text;
                        h = JSONParse.Buttons.Button59.Height.ToString();
                        w = JSONParse.Buttons.Button59.Width.ToString();
                        break;
                    case 60:
                        ButtonText = JSONParse.Buttons.Button60.Text;
                        h = JSONParse.Buttons.Button60.Height.ToString();
                        w = JSONParse.Buttons.Button60.Width.ToString();
                        break;
                    case 61:
                        ButtonText = JSONParse.Buttons.Button61.Text;
                        h = JSONParse.Buttons.Button61.Height.ToString();
                        w = JSONParse.Buttons.Button61.Width.ToString();
                        break;
                    case 62:
                        ButtonText = JSONParse.Buttons.Button62.Text;
                        h = JSONParse.Buttons.Button62.Height.ToString();
                        w = JSONParse.Buttons.Button62.Width.ToString();
                        break;
                    case 63:
                        ButtonText = JSONParse.Buttons.Button63.Text;
                        h = JSONParse.Buttons.Button63.Height.ToString();
                        w = JSONParse.Buttons.Button63.Width.ToString();
                        break;
                    case 64:
                        ButtonText = JSONParse.Buttons.Button64.Text;
                        h = JSONParse.Buttons.Button64.Height.ToString();
                        w = JSONParse.Buttons.Button64.Width.ToString();
                        break;
                    case 65:
                        ButtonText = JSONParse.Buttons.Button65.Text;
                        h = JSONParse.Buttons.Button65.Height.ToString();
                        w = JSONParse.Buttons.Button65.Width.ToString();
                        break;
                    case 66:
                        ButtonText = JSONParse.Buttons.Button66.Text;
                        h = JSONParse.Buttons.Button66.Height.ToString();
                        w = JSONParse.Buttons.Button66.Width.ToString();
                        break;
                    case 67:
                        ButtonText = JSONParse.Buttons.Button67.Text;
                        h = JSONParse.Buttons.Button67.Height.ToString();
                        w = JSONParse.Buttons.Button67.Width.ToString();
                        break;
                    case 68:
                        ButtonText = JSONParse.Buttons.Button68.Text;
                        h = JSONParse.Buttons.Button68.Height.ToString();
                        w = JSONParse.Buttons.Button68.Width.ToString();
                        break;
                    case 69:
                        ButtonText = JSONParse.Buttons.Button69.Text;
                        h = JSONParse.Buttons.Button69.Height.ToString();
                        w = JSONParse.Buttons.Button69.Width.ToString();
                        break;
                    case 70:
                        ButtonText = JSONParse.Buttons.Button70.Text;
                        h = JSONParse.Buttons.Button70.Height.ToString();
                        w = JSONParse.Buttons.Button70.Width.ToString();
                        break;
                    case 71:
                        ButtonText = JSONParse.Buttons.Button71.Text;
                        h = JSONParse.Buttons.Button71.Height.ToString();
                        w = JSONParse.Buttons.Button71.Width.ToString();
                        break;
                    case 72:
                        ButtonText = JSONParse.Buttons.Button72.Text;
                        h = JSONParse.Buttons.Button72.Height.ToString();
                        w = JSONParse.Buttons.Button72.Width.ToString();
                        break;
                    case 73:
                        ButtonText = JSONParse.Buttons.Button73.Text;
                        h = JSONParse.Buttons.Button73.Height.ToString();
                        w = JSONParse.Buttons.Button73.Width.ToString();
                        break;
                    case 74:
                        ButtonText = JSONParse.Buttons.Button74.Text;
                        h = JSONParse.Buttons.Button74.Height.ToString();
                        w = JSONParse.Buttons.Button74.Width.ToString();
                        break;
                    case 75:
                        ButtonText = JSONParse.Buttons.Button75.Text;
                        h = JSONParse.Buttons.Button75.Height.ToString();
                        w = JSONParse.Buttons.Button75.Width.ToString();
                        break;
                    case 76:
                        ButtonText = JSONParse.Buttons.Button76.Text;
                        h = JSONParse.Buttons.Button76.Height.ToString();
                        w = JSONParse.Buttons.Button76.Width.ToString();
                        break;
                    case 77:
                        ButtonText = JSONParse.Buttons.Button77.Text;
                        h = JSONParse.Buttons.Button77.Height.ToString();
                        w = JSONParse.Buttons.Button77.Width.ToString();
                        break;
                    case 78:
                        ButtonText = JSONParse.Buttons.Button78.Text;
                        h = JSONParse.Buttons.Button78.Height.ToString();
                        w = JSONParse.Buttons.Button78.Width.ToString();
                        break;
                    case 79:
                        ButtonText = JSONParse.Buttons.Button79.Text;
                        h = JSONParse.Buttons.Button79.Height.ToString();
                        w = JSONParse.Buttons.Button79.Width.ToString();
                        break;
                    case 80:
                        ButtonText = JSONParse.Buttons.Button80.Text;
                        h = JSONParse.Buttons.Button80.Height.ToString();
                        w = JSONParse.Buttons.Button80.Width.ToString();
                        break;
                    case 81:
                        ButtonText = JSONParse.Buttons.Button81.Text;
                        h = JSONParse.Buttons.Button81.Height.ToString();
                        w = JSONParse.Buttons.Button81.Width.ToString();
                        break;
                    case 82:
                        ButtonText = JSONParse.Buttons.Button82.Text;
                        h = JSONParse.Buttons.Button82.Height.ToString();
                        w = JSONParse.Buttons.Button82.Width.ToString();
                        break;
                    case 83:
                        ButtonText = JSONParse.Buttons.Button83.Text;
                        h = JSONParse.Buttons.Button83.Height.ToString();
                        w = JSONParse.Buttons.Button83.Width.ToString();
                        break;
                    case 84:
                        ButtonText = JSONParse.Buttons.Button84.Text;
                        h = JSONParse.Buttons.Button84.Height.ToString();
                        w = JSONParse.Buttons.Button84.Width.ToString();
                        break;
                    case 85:
                        ButtonText = JSONParse.Buttons.Button85.Text;
                        h = JSONParse.Buttons.Button85.Height.ToString();
                        w = JSONParse.Buttons.Button85.Width.ToString();
                        break;
                    case 86:
                        ButtonText = JSONParse.Buttons.Button86.Text;
                        h = JSONParse.Buttons.Button86.Height.ToString();
                        w = JSONParse.Buttons.Button86.Width.ToString();
                        break;
                    case 87:
                        ButtonText = JSONParse.Buttons.Button87.Text;
                        h = JSONParse.Buttons.Button87.Height.ToString();
                        w = JSONParse.Buttons.Button87.Width.ToString();
                        break;
                    case 88:
                        ButtonText = JSONParse.Buttons.Button88.Text;
                        h = JSONParse.Buttons.Button88.Height.ToString();
                        w = JSONParse.Buttons.Button88.Width.ToString();
                        break;
                    case 89:
                        ButtonText = JSONParse.Buttons.Button89.Text;
                        h = JSONParse.Buttons.Button89.Height.ToString();
                        w = JSONParse.Buttons.Button89.Width.ToString();
                        break;
                    case 90:
                        ButtonText = JSONParse.Buttons.Button90.Text;
                        h = JSONParse.Buttons.Button90.Height.ToString();
                        w = JSONParse.Buttons.Button90.Width.ToString();
                        break;
                    case 91:
                        ButtonText = JSONParse.Buttons.Button91.Text;
                        h = JSONParse.Buttons.Button91.Height.ToString();
                        w = JSONParse.Buttons.Button91.Width.ToString();
                        break;
                    case 92:
                        ButtonText = JSONParse.Buttons.Button92.Text;
                        h = JSONParse.Buttons.Button92.Height.ToString();
                        w = JSONParse.Buttons.Button92.Width.ToString();
                        break;
                    case 93:
                        ButtonText = JSONParse.Buttons.Button93.Text;
                        h = JSONParse.Buttons.Button93.Height.ToString();
                        w = JSONParse.Buttons.Button93.Width.ToString();
                        break;
                    case 94:
                        ButtonText = JSONParse.Buttons.Button94.Text;
                        h = JSONParse.Buttons.Button94.Height.ToString();
                        w = JSONParse.Buttons.Button94.Width.ToString();
                        break;
                    case 95:
                        ButtonText = JSONParse.Buttons.Button95.Text;
                        h = JSONParse.Buttons.Button95.Height.ToString();
                        w = JSONParse.Buttons.Button95.Width.ToString();
                        break;
                    case 96:
                        ButtonText = JSONParse.Buttons.Button96.Text;
                        h = JSONParse.Buttons.Button96.Height.ToString();
                        w = JSONParse.Buttons.Button96.Width.ToString();
                        break;
                    case 97:
                        ButtonText = JSONParse.Buttons.Button97.Text;
                        h = JSONParse.Buttons.Button97.Height.ToString();
                        w = JSONParse.Buttons.Button97.Width.ToString();
                        break;
                    case 98:
                        ButtonText = JSONParse.Buttons.Button98.Text;
                        h = JSONParse.Buttons.Button98.Height.ToString();
                        w = JSONParse.Buttons.Button98.Width.ToString();
                        break;
                    case 99:
                        ButtonText = JSONParse.Buttons.Button99.Text;
                        h = JSONParse.Buttons.Button99.Height.ToString();
                        w = JSONParse.Buttons.Button99.Width.ToString();
                        break;
                    case 100:
                        ButtonText = JSONParse.Buttons.Button100.Text;
                        h = JSONParse.Buttons.Button100.Height.ToString();
                        w = JSONParse.Buttons.Button100.Width.ToString();
                        break;
                    default:
                        MessageBox.Show("Maxed out buttons.");
                        this.Close();
                        return;
                        
                }

                Button dynamicButton = new Button();
                dynamicButton.Text = ButtonText;
                dynamicButton.Location = new Point(20, 150);
                dynamicButton.Height = int.Parse(h);
                dynamicButton.Width = int.Parse(w);
                //dynamicButton = JsonConvert.DeserializeObject<Button>(json);
                Controls.Add(dynamicButton);

            }




        }
    }
}
