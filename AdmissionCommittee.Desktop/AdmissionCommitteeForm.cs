using System.ComponentModel;
using AdmissionCommittee.Models;
using AdmissionCommittee.Services.Contracts;

namespace AdmissionCommittee.Desktop
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AdmissionCommitteeForm : Form
    {
        private readonly IAdmissionService service;
        private BindingList<Student> students;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public AdmissionCommitteeForm(IAdmissionService service)
        {
            InitializeComponent();

            this.service = service;
            students = new BindingList<Student>(service.GetAllStudents().ToList());

            dataGridView1.DataSource = students;
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.CellPainting += DataGridView1_CellPainting;

            UpdateStatistics();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            using var form = new StudentForm();
            if (form.ShowDialog() == DialogResult.OK && form.ResultStudent != null)
            {
                try
                {
                    service.AddStudent(form.ResultStudent);
                    students.Add(form.ResultStudent);
                    UpdateStatistics();
                    MessageBox.Show("Студент добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not Student student)
            {
                MessageBox.Show("Выберите студента для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var form = new StudentForm(student);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    service.UpdateStudent(form.ResultStudent!);
                    UpdateStatistics();
                    MessageBox.Show("Данные обновлены!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not Student student)
            {
                MessageBox.Show("Выберите студента для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Вы действительно хотите удалить студента?\n\n{student.FullName}\nДата рождения: {student.DateBirth:dd.MM.yyyy}",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    service.DeleteStudent(student.Id);
                    students.Remove(student);
                    UpdateStatistics();
                    MessageBox.Show("Студент успешно удалён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateStatistics()
        {
            toolStripStatusLabel1.Text = service.GetStatistics();
        }

        private void DataGridView1_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 &&
                dataGridView1.Columns[e.ColumnIndex].Name == "TotalScore" &&
                e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                var student = (Student)dataGridView1.Rows[e.RowIndex].DataBoundItem!;
                int grade = student.TotalScore;

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

                TextRenderer.DrawText(e.Graphics, grade.ToString(),
                    dataGridView1.Font, e.CellBounds, Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }
    }
}
