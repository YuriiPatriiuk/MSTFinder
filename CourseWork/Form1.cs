using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        List<Vertex> vertices;
        List<Edge> edges;
        DrawGraph drawGraph;
        List<Edge> MST = new List<Edge>();

        int selected1;
        int selected2;

        public Form1()
        {
            InitializeComponent();
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            drawGraph = new DrawGraph(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = drawGraph.GetBitmap();
            solvingsComboBox.Items.Add("Прима");
            solvingsComboBox.Items.Add("Крускала");
            solvingsComboBox.Items.Add("Борувки");
            speedTrackBar.Maximum = -1;
            speedTrackBar.Minimum = -10;
            speedTrackBar.Value = speedTrackBar.Minimum;
        }

        private DialogResult InputBox(string title, string promptText, ref string value)    
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            form.Text = title;
            label.Text = promptText;
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            label.SetBounds(50, 36, 50, 13);
            textBox.SetBounds(50, 86, 200, 20);
            buttonOk.SetBounds(50, 130, 100, 40);
            buttonCancel.SetBounds(150, 130, 100, 40);
            label.AutoSize = true;
            form.ClientSize = new Size(300, 200);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        async private void DrawMST(List<Edge> e)
        {
            for (int i = 0; i < e.Count; i++)
            {
                await Task.Delay(speedTrackBar.Value*(-100));
                drawGraph.GetGraphics().DrawLine(new Pen(Color.Red, 3), vertices[e[i].v1].x, vertices[e[i].v1].y, vertices[e[i].v2].x, vertices[e[i].v2].y);
                for (int j = 0; j < vertices.Count; j++)
                {
                    drawGraph.DrawVertex(vertices[j].x, vertices[j].y, (j + 1).ToString());
                }
                pictureBox.Image = drawGraph.GetBitmap();
            }
            
        }
        private int calculateMSTWeight()
        {
            int res = 0;
            foreach(var elem in MST)
            {
                res += elem.weight;
            }
            return res;
        }

        private void updateListBox()
        {
            int[,] matrix = new int[vertices.Count, vertices.Count];
            drawGraph.FillWeightMatrix(edges, vertices.Count, matrix);
            listBoxWeightMatrix.Items.Clear();
            string line = "    ";
            for (int i = 0; i < vertices.Count; i++)
                line += (i + 1) + "   ";
            listBoxWeightMatrix.Items.Add(line);
            for (int i = 0; i < vertices.Count; i++)
            {
                line = (i + 1) + "| ";
                for (int j = 0; j < vertices.Count; j++)
                    line += matrix[i, j] + "   ";
                listBoxWeightMatrix.Items.Add(line);
            }
        }

        private void mouseButton_Click(object sender, EventArgs e)
        {
            mouseButton.Enabled = false;
            vertexButton.Enabled = true;
            edgeButton.Enabled = true;
            deleteButton.Enabled = true;
            clearButton.Enabled = true;
            drawGraph.ClearSheet();
            drawGraph.DrawWholeGraph(edges, vertices);
            pictureBox.Image = drawGraph.GetBitmap();
            selected1 = -1;
            weightLabel.Text = "Вага МОД:";
            comparisonLabel.Text = "Порівнянь:";
            MST.Clear();
        }

        private void vertexButton_Click(object sender, EventArgs e)
        {
            vertexButton.Enabled = false;
            mouseButton.Enabled = true;
            edgeButton.Enabled = true;
            deleteButton.Enabled = true;
            clearButton.Enabled = true;
            drawGraph.ClearSheet();
            drawGraph.DrawWholeGraph(edges, vertices);
            pictureBox.Image = drawGraph.GetBitmap();
            weightLabel.Text = "Вага МОД:";
            comparisonLabel.Text = "Порівнянь:";
            MST.Clear();
        }

        private void edgeButton_Click(object sender, EventArgs e)
        {
            edgeButton.Enabled = false;
            vertexButton.Enabled = true;
            mouseButton.Enabled = true;
            deleteButton.Enabled = true;
            clearButton.Enabled = true;
            drawGraph.ClearSheet();
            drawGraph.DrawWholeGraph(edges, vertices);
            pictureBox.Image = drawGraph.GetBitmap();
            selected1 = -1;
            selected2 = -1;
            weightLabel.Text = "Вага МОД:";
            comparisonLabel.Text = "Порівнянь:";
            MST.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            edgeButton.Enabled = true;
            vertexButton.Enabled = true;
            mouseButton.Enabled = true;
            clearButton.Enabled = true;
            drawGraph.ClearSheet();
            drawGraph.DrawWholeGraph(edges, vertices);
            pictureBox.Image = drawGraph.GetBitmap();
            weightLabel.Text = "Вага МОД:";
            comparisonLabel.Text = "Порівнянь:";
            MST.Clear();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = true;
            edgeButton.Enabled = true;
            vertexButton.Enabled = true;
            mouseButton.Enabled = true;
            clearButton.Enabled = false;
            weightLabel.Text = "Вага МОД:";
            comparisonLabel.Text = "Порівнянь:";
            const string message = "Ви дійсно хочете видалити граф?";
            const string caption = "Видалення";
            var acceptWindow = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if(acceptWindow == DialogResult.Yes)
            {
                vertices.Clear();
                edges.Clear();
                MST.Clear();
                drawGraph.ClearSheet();
                pictureBox.Image = drawGraph.GetBitmap();
                updateListBox();
            }
        }

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            if(!mouseButton.Enabled)
            {
                bool isEnable = false;
                for (int i = 0; i < vertices.Count; i++)
                {
                    if(Math.Pow(vertices[i].x - e.X, 2) + Math.Pow(vertices[i].y - e.Y, 2) <= Math.Pow(drawGraph.Radius,2))
                    {
                        isEnable = true;
                        if (selected1 != -1)
                        {
                            selected1 = -1;
                            drawGraph.ClearSheet();
                            drawGraph.DrawWholeGraph(edges, vertices);
                            pictureBox.Image = drawGraph.GetBitmap();
                        }
                        if (selected1 == -1)
                        {
                            drawGraph.DrawSelectedVertex(vertices[i].x, vertices[i].y);
                            selected1 = i;
                            pictureBox.Image = drawGraph.GetBitmap();
                            break;
                        }  
                    }
                }
                if (!isEnable)
                {
                    selected1 -= 1;
                    drawGraph.ClearSheet();
                    drawGraph.DrawWholeGraph(edges, vertices);
                    pictureBox.Image = drawGraph.GetBitmap();
                }
            }
            else if(!vertexButton.Enabled)
            {
                vertices.Add(new Vertex(e.X, e.Y));
                drawGraph.DrawVertex(e.X, e.Y, vertices.Count.ToString());
                pictureBox.Image = drawGraph.GetBitmap();
                updateListBox();
            }
            else if(!edgeButton.Enabled)
            {
                drawGraph.ClearSheet();
                drawGraph.DrawWholeGraph(edges, vertices);
                for (int i = 0; i < vertices.Count; i++)
                {
                    if (Math.Pow(vertices[i].x - e.X, 2) + Math.Pow(vertices[i].y - e.Y, 2) <= Math.Pow(drawGraph.Radius, 2))
                    {
                        if (selected1 == -1)
                        {
                            drawGraph.DrawSelectedVertex(vertices[i].x, vertices[i].y);
                            selected1 = i;
                            pictureBox.Image = drawGraph.GetBitmap();
                            break;
                        }
                        if (selected2 == -1 && selected1 != i)
                        {
                            string value = "";
                            int weight;
                            if (InputBox("Вага ребра", "Яка вага цього ребра?", ref value) == DialogResult.OK )
                            {
                                if (Int32.TryParse(value, out weight) && weight > 0)
                                {
                                    selected2 = i;
                                    Edge edge = new Edge(selected1, selected2, weight);
                                    Edge check = edges.Find(x => (x.v1 == selected1 && x.v2 == selected2) || (x.v1 == selected2 && x.v2 == selected1));
                                    if (check != null)
                                    {
                                        edges.Remove(check);
                                        drawGraph.ClearSheet();
                                        drawGraph.DrawWholeGraph(edges, vertices);
                                        pictureBox.Image = drawGraph.GetBitmap();
                                    }
                                    edges.Add(edge);
                                    drawGraph.DrawEdge(vertices[selected1], vertices[selected2], edges[edges.Count - 1]);
                                    selected1 = -1;
                                    selected2 = -1;
                                    pictureBox.Image = drawGraph.GetBitmap();
                                    break;
                                }
                                else
                                    MessageBox.Show("Некоректне введення значення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                updateListBox();
            }
            else if(!deleteButton.Enabled)
            {
                if (vertices.Count > 0)
                {
                    bool check = false;
                    int k = 0;
                    do
                    {
                        if (Math.Pow(vertices[k].x - e.X, 2) + Math.Pow(vertices[k].y - e.Y, 2) <= Math.Pow(drawGraph.Radius, 2))
                        {
                            for (int j = 0; j < edges.Count; j++)
                            {
                                if (k == edges[j].v1 || k == edges[j].v2)
                                {
                                    edges.RemoveAt(j);
                                    j--;
                                }
                                else
                                {
                                    if (edges[j].v1 > k)
                                        edges[j].v1--;
                                    if (edges[j].v2 > k)
                                        edges[j].v2--;
                                }
                            }
                            vertices.RemoveAt(k);
                            check = true;
                        }
                        ++k;
                    } while (check != true && k < vertices.Count);

                    if (!check)
                    {
                        for (int i = 0; i < edges.Count; i++)
                        {
                            if (((e.X - vertices[edges[i].v1].x) * (vertices[edges[i].v2].y - vertices[edges[i].v1].y) / (vertices[edges[i].v2].x - vertices[edges[i].v1].x) + vertices[edges[i].v1].y) <= (e.Y + 4) &&
                            ((e.X - vertices[edges[i].v1].x) * (vertices[edges[i].v2].y - vertices[edges[i].v1].y) / (vertices[edges[i].v2].x - vertices[edges[i].v1].x) + vertices[edges[i].v1].y) >= (e.Y - 4))
                            {
                                if ((vertices[edges[i].v1].x <= vertices[edges[i].v2].x && vertices[edges[i].v1].x <= e.X && e.X <= vertices[edges[i].v2].x) ||
                                    (vertices[edges[i].v1].x >= vertices[edges[i].v2].x && vertices[edges[i].v1].x >= e.X && e.X >= vertices[edges[i].v2].x))
                                {
                                    edges.RemoveAt(i);
                                    check = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (check)
                    {
                        drawGraph.ClearSheet();
                        drawGraph.DrawWholeGraph(edges, vertices);
                        pictureBox.Image = drawGraph.GetBitmap();
                    }
                }
                updateListBox();
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            if (vertices.Count != 0 && edges.Count != 0)
            {
                if (drawGraph.IsConnected(vertices.Count,edges))
                {
                    drawGraph.DrawWholeGraph(edges, vertices);
                    pictureBox.Image = drawGraph.GetBitmap();
                    int comparisons = 0;
                    if (solvingsComboBox.SelectedIndex == 0)
                    {
                        MST = drawGraph.MST_prim(vertices, edges, ref comparisons);
                    }
                    else if (solvingsComboBox.SelectedIndex == 1)
                    {
                        MST = drawGraph.MST_kruskal(vertices, edges, ref comparisons);
                    }
                    else if (solvingsComboBox.SelectedIndex == 2)
                    {
                        MST = drawGraph.MST_boruvka(vertices, edges, ref comparisons);
                    }
                    else
                    {
                        MessageBox.Show("Виберіть метод пошуку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    weightLabel.Text = "Вага МОД: " + calculateMSTWeight().ToString();
                    comparisonLabel.Text = "Порівнянь: " + comparisons.ToString();
                    DrawMST(MST);
                }
                else
                    MessageBox.Show("Намалюйте тільки один граф!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Для початку намалюйте граф!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void saveResultButton_Click(object sender, EventArgs e)
        {
            if (!(MST.Count == 0))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "MST";
                sfd.Filter = "Text files(*.txt)|*.txt|PNG files(*.png)|*.png";
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = sfd.FileName;
                string text = "";
                foreach (var item in MST)
                {
                    text += (item.v1).ToString() + " - " + (item.v2).ToString() + " Вага: " + (item.weight).ToString() + '\n';
                }
                
                text += "Вага МОД: " + calculateMSTWeight()+'\n';
                System.IO.File.WriteAllText(filename, text);
                MessageBox.Show("Файл збережено успішно!");
            }
            else
                MessageBox.Show("Для збереження спочатку створіть мінімальне остовне дерево!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
