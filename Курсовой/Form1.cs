using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;

namespace Курсовой
{

    public partial class SolarSystem : Form
    {
        private Bitmap offScreenBitmap;
        private Timer animationTimer;
        private List<Planet> planets;
        private List<Moon> moons;
        Star star;

        public const int TIMER_INTERVAL = 10; // Интервал таймера в миллисекундах
        public string activeCelestial = "None";
        public float slowModifier = 1f;
        public int test = 0;
        public SolarSystem()
        {
            InitializeComponent();
            star = new Star("Солнце", Color.Yellow, 400f, 400f, 30f);

            // Добавляем планеты
            planets = new List<Planet>()
            {
                new Planet("Меркурий", Color.Silver, 3f, 70f, 0.00702f, star),
                new Planet("Венера", Color.DarkOrange, 4f, 110f, 0.0028f, star),
                new Planet("Земля", Color.Blue, 5f, 150f, 0.00199f, star),
                new Planet("Марс", Color.Red, 5f, 190f, 0.00103f, star),
                new Planet("Юпитер", Color.GreenYellow, 20f, 240f, 0.000464f, star),
                new Planet("Сатурн", Color.LightYellow, 15f, 310f, 0.000186f, star),
                new Planet("Уран", Color.BlueViolet,  5f, 370f, 0.0000652f, star),
                new Planet("Нептун", Color.AliceBlue, 3f, 390f, 0.0000327f, star),
            };

            moons = new List<Moon>()
            {
                new Moon("Луна", Color.Silver, 1f, 7f, 0.0199f, planets.Find(x => x.name == "Земля")),
                new Moon("Фобос", Color.DarkOrange, 1f, 7f, 0.2f, planets.Find(x => x.name == "Марс")),
                new Moon("Деймос", Color.DarkOrange, 1f, 7f, 0.1f, planets.Find(x => x.name == "Марс")),
                new Moon("Ио", Color.DarkOrange, 1f, 24f, 0.1f, planets.Find(x => x.name == "Юпитер")),
                new Moon("Европа", Color.DarkOrange, 1f, 25f, 0.06f, planets.Find(x => x.name == "Юпитер")),
                new Moon("Ганимед", Color.DarkOrange, 1f, 26f, 0.04f, planets.Find(x => x.name == "Юпитер")),
                new Moon("Каллисто", Color.DarkOrange, 1f, 27f, 0.025f, planets.Find(x => x.name == "Юпитер")),
                new Moon("Титан", Color.DarkOrange, 1f, 20f, 0.028f, planets.Find(x => x.name == "Сатурн")),
                new Moon("Миранда", Color.DarkOrange, 1f, 9f, 0.2f, planets.Find(x => x.name == "Уран")),
                new Moon("Ариэль", Color.DarkOrange, 1f, 10f, 0.1f, planets.Find(x => x.name == "Уран")),
                new Moon("Умбриэль", Color.DarkOrange, 1f, 11f, 0.06f, planets.Find(x => x.name == "Уран")),
                new Moon("Титания", Color.DarkOrange, 1f, 12f, 0.03f, planets.Find(x => x.name == "Уран")),
                new Moon("Оберон", Color.DarkOrange, 1f, 13f, 0.02f, planets.Find(x => x.name == "Уран")),
                new Moon("Тритон", Color.DarkOrange, 1f, 7f, -0.04f, planets.Find(x => x.name == "Нептун")),

            };

            // Строим дерево небесных тел
            int amountPlanets = 0;
            foreach (Planet planet in planets)
            {
                treeView1.Nodes.Add(new TreeNode(planet.name));
                foreach (Moon moon in moons)
                {
                    if (moon.mainCelestial.name == planet.name)
                    {
                        treeView1.Nodes[amountPlanets].Nodes.Add(new TreeNode(moon.name));
                    }
                }
                amountPlanets++;
            }

            // Настройка таймера анимации
            animationTimer = new Timer
            {
                Interval = TIMER_INTERVAL
            };
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = test.ToString();
            ++test;
            if (activeCelestial == "None")
            {
                uncheckCelestials();
            }
            else
            {
                uncheckCelestials();
                var activePlanet = planets.Find(x => x.name == activeCelestial);
                if (activePlanet != null)
                {
                    activePlanet.isActive = true;
                }

                var activeMoon = moons.Find(x => x.name == activeCelestial);
                if (activeMoon != null)
                {
                    activeMoon.isActive = true;
                }
            }
            using (Graphics g = Graphics.FromImage(offScreenBitmap))
            {
                g.Clear(Color.FromArgb(2, 22, 49));
                DrawCelestial(star, g);
                foreach (var planet in planets)
                {
                    planet.UpdatePosition(slowModifier);
                    DrawCelestial(planet, g);
                }
                foreach (var moon in moons)
                {
                    moon.UpdatePosition(slowModifier);
                    DrawCelestial(moon, g);
                }
            }
            pictureBox1.Invalidate();
        }

        private void uncheckCelestials()
        {
            foreach (Planet planet in planets)
            {
                planet.isActive = false;
            }
            foreach (Moon moon in moons)
            {
                moon.isActive = false;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            slowModifier = trackBar1.Value / 100;
        }

        private void DrawCelestial(Celestial planet, Graphics g)
        {
            Color edgeColor = ControlPaint.Dark(planet.color, 0.30f);

            // Обводка небесного тела
            if (planet.isActive)
            {
                int borderSize = 6;
                int edgeSize = 5;
                g.FillEllipse(new SolidBrush(Color.White), planet.x - planet.radius - borderSize, planet.y - planet.radius - borderSize, (planet.radius + borderSize) * 2, (planet.radius + borderSize) * 2);
                g.FillEllipse(new SolidBrush(edgeColor), planet.x - planet.radius - edgeSize, planet.y - planet.radius - edgeSize, (planet.radius + edgeSize) * 2, (planet.radius + edgeSize) * 2);
            }
            else
            {
                int edgeSize = 2;
                g.FillEllipse(new SolidBrush(edgeColor), planet.x - planet.radius - edgeSize, planet.y - planet.radius - edgeSize, (planet.radius + edgeSize) * 2, (planet.radius + edgeSize) * 2);
            }

            // Небесное тело
            g.FillEllipse(new SolidBrush(planet.color), planet.x - planet.radius, planet.y - planet.radius, planet.radius * 2, planet.radius * 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            offScreenBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(offScreenBitmap, 0, 0);
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool isActiveCelestial = false;

            // При выделении небесного тела, обозначаем его активным
            // и отменяем выделение на остальных небесных телах
            if (e.Node.Checked)
            {
                activeCelestial = e.Node.Text;

                //Динамически определяем нужный файл с описанием
                var resourceManagerType = typeof(Properties.Resources);
                var propertyInfo = resourceManagerType.GetProperty(activeCelestial, BindingFlags.NonPublic | BindingFlags.Static);

                // Выводим описание на экран
                string infoCelestial;
                if (propertyInfo != null)
                {
                    infoCelestial = propertyInfo.GetValue(null, null) as string;
                }
                else
                {
                    infoCelestial = "Ошибка в данных, такое небесное тело не найдено. Сообщите об этом разработчику программы.";
                }
                textBox1.Text = infoCelestial;


                // Проверяем все небесные тела, кроме выделенного, и отменяем выделение
                foreach (TreeNode cur_node in e.Node.TreeView.Nodes)
                {
                    if (cur_node != e.Node)
                    {
                        cur_node.Checked = false;
                    }
                    // Проверяем спутники по тому же принципу
                    foreach (TreeNode treeNode in cur_node.Nodes)
                    {
                        if (treeNode != e.Node)
                        {
                            treeNode.Checked = false;
                        }
                    }
                }
            }

            // Проверяем есть ли активное выделение. Если нет, обнуляем активное небесное тело
            foreach (TreeNode cur_node in e.Node.TreeView.Nodes)
            {
                if (cur_node.Checked == true)
                {
                    isActiveCelestial = true;
                }
                // проверяем спутники по тому же признаку
                foreach (TreeNode treeNode in cur_node.Nodes)
                {
                    if (treeNode.Checked == true)
                    {
                        isActiveCelestial = true;
                    }
                }
            }
            if (!isActiveCelestial)
            {
                activeCelestial = "None";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // Алгоритм расчета нового положения сам поправит координаты
            // так, чтобы планета/луна была на расстоянии радиуса от центрального тела
            foreach (Planet planet in planets)
            {
                planet.x = random.Next(1, pictureBox1.Width);
                planet.y = random.Next(1, pictureBox1.Height);
            }
            foreach (Moon moon in moons)
            {
                moon.isActive = false;
                moon.x = random.Next(1, pictureBox1.Width);
                moon.y = random.Next(1, pictureBox1.Height);
            }
        }
    }

    public abstract class Celestial
    {
        public string name { get; set; }
        public Color color { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float radius { get; set; }
        public bool isActive { get; set; }
        
        public Celestial(string nameGiven, Color colorGiven, float xGiven, float yGiven, float radiusGiven)
        {
            name = nameGiven;
            color = colorGiven;
            x = xGiven;
            y = yGiven;
            radius = radiusGiven;
            isActive = false;
        }
    }

    public class Star : Celestial
    {
        public Star(string nameGiven, Color colorGiven, float xGiven, float yGiven, float radiusGiven) 
            : base(nameGiven, colorGiven, xGiven, yGiven, radiusGiven)
        {
            // Вроде ничего и не надо
        }
    }

    public class Planet : Celestial
    {
        public float orbit { get; set; }
        public float speed { get; set; }
        public Star mainCelestial { get; set; }

        public Planet(string nameGiven, Color colorGiven, float radiusGiven, 
            float orbitGiven, float speedGiven, Star mainCelestialGiven)
            : base(nameGiven, colorGiven, 0, 0, radiusGiven)
        {
            orbit = orbitGiven;
            speed = speedGiven;
            mainCelestial = mainCelestialGiven;
        }

        public void UpdatePosition(float slowModifier)
        {
            float centerX = mainCelestial.x;
            float centerY = mainCelestial.y;
            float deltaTime = SolarSystem.TIMER_INTERVAL;

            // Вычисление угла относительно центра на данный момент
            float angle = (float)Math.Atan2(y - centerY, x - centerX);

            // Вычисление угла относительно центра на следующий момент
            float newAngle = angle + speed * deltaTime / slowModifier;

            // Вычисление новых координат
            x = centerX + orbit * (float)Math.Cos(newAngle);
            y = centerY + orbit * (float)Math.Sin(newAngle);
        }
    }

    public class Moon : Celestial
    {
        public float orbit { get; set; }
        public float speed { get; set; }
        public Planet mainCelestial { get; set; }

        public Moon(string nameGiven, Color colorGiven, float radiusGiven,
            float orbitGiven, float speedGiven, Planet mainCelestialGiven)
            : base(nameGiven, colorGiven, 0, 0, radiusGiven)
        {
            orbit = orbitGiven;
            speed = speedGiven;
            mainCelestial = mainCelestialGiven;
        }

        public void UpdatePosition(float slowModifier)
        {
            float centerX = mainCelestial.x;
            float centerY = mainCelestial.y;
            float deltaTime = SolarSystem.TIMER_INTERVAL;

            // Вычисление угла относительно центра на данный момент
            float angle = (float)Math.Atan2(y - centerY, x - centerX);

            // Вычисление угла относительно центра на следующий момент
            float newAngle = angle + speed * deltaTime / slowModifier;

            // Вычисление новых координат
            x = centerX + orbit * (float)Math.Cos(newAngle);
            y = centerY + orbit * (float)Math.Sin(newAngle);
        }
    }
}
