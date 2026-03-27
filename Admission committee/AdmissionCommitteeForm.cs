namespace AdmissionCommittee
{
    public partial class AdmissionCommitteeForm : Form
    {
        private List<Student> students = new List<Student>();

        public AdmissionCommitteeForm()
        {
            InitializeComponent();
            Students();
            dataGridView1.DataSource = students;
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            UpdateStatistics();

            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void DataGridView1_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "TotalScore" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                var student = (Student)dataGridView1.Rows[e.RowIndex].DataBoundItem!;
                float grade = student.TotalScore;

                var maxGrade = 300.0f;
                var ratio = Math.Clamp(grade / maxGrade, 0, 1);

                var margin = 2;
                var barWidth = (int)((e.CellBounds.Width - (margin * 2)) * ratio);
                var barRect = new Rectangle(
                    e.CellBounds.X + margin,
                    e.CellBounds.Y + margin,
                    barWidth,
                    e.CellBounds.Height - (margin * 2) - 1
                 );

                Color barColor = grade >= 250 ? Color.Green : (grade >= 200 ? Color.Yellow : Color.Coral);

                using (SolidBrush brush = new SolidBrush(barColor))
                {
                    e.Graphics!.FillRectangle(brush, barRect);
                }

                TextRenderer.DrawText(e.Graphics, grade.ToString("0.00"),
                    dataGridView1.Font, e.CellBounds, Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }

        private void SchoolMagazineForm_Load(object sender, EventArgs e)
        {

        }

        private void Students()
        {
            students.Add(new Student
            {
                FullName = "Артемьев Анатолий Андреевич",
                Gender = "М",
                DateBirth = new DateTime(2000, 8, 12),
                FormOfEducation = "Очное",
                MathScores = 90,
                RusScores = 70,
                ComputerScienceScores = 100,
            }
            );

            students.Add(new Student
            {
                FullName = "Петрова Анастасия Борисовна",
                Gender = "Ж",
                DateBirth = new DateTime(1998, 10, 25),
                FormOfEducation = "Очное-заочное",
                MathScores = 70,
                RusScores = 50,
                ComputerScienceScores = 60,
            }
            );

            students.Add(new Student
            {
                FullName = "Сидоров Александр Фёдорович",
                Gender = "М",
                DateBirth = new DateTime(2003, 2, 10),
                FormOfEducation = "Заочное",
                MathScores = 80,
                RusScores = 90,
                ComputerScienceScores = 95,
            }
            );
        }

        private void UpdateStatistics()
        {
            if (students.Count == 0)
            {
                toolStripStatusLabel1.Text = "Нет данных";
                return;
            }

            int totalStudent = students.Count;
            int passedStudent = students.Count(s => s.TotalScore > 150);
            double avarageScore = students.Average(s => s.TotalScore);
            int maxScore = students.Max(s => s.TotalScore);
            int minScore = students.Min(s => s.TotalScore);


            toolStripStatusLabel1.Text = $"Всего: {totalStudent} | " +
                $"> 150 баллов: {passedStudent} | " +
                $"Средний: {avarageScore:F1} | " +
                $"Худший: {minScore} | " +
                $"Лучший: {maxScore}";
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите студента для редактирования!", "Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var student = (Student)dataGridView1.CurrentRow.DataBoundItem;


            using (var editForm = new StudentEditForm(student))
            {
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = students;

                    UpdateStatistics();

                    MessageBox.Show("Редактирование успешно!");
                }
                else
                {
                    MessageBox.Show("Ошибка редактирования");
                }
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            using (var addForm = new StudentAddForm())
            {
                var result = addForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (addForm.NewStudent != null)
                    {
                        students.Add(addForm.NewStudent);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = students;

                        UpdateStatistics();

                        MessageBox.Show("Студент добавлен!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления");
                    }
                }
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(
                    "Выберите студента для удаления!",
                    "Внимание!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var student = dataGridView1.CurrentRow.DataBoundItem as Student;

            var result = MessageBox.Show(
                $"Вы действительно хотите удалить студента?\n\n{student.FullName}\nДата рождения: {student.DateBirth:dd.MM.yyyy}",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                students.Remove(student);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;

                UpdateStatistics();

                MessageBox.Show(
                    "Студент успешно удалён!",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
