using equipment_accounting_system.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace equipment_accounting_system.Additional_Forms
{
    public partial class frm_Dept_and_Roles : Form
    {
        private db_Helper dbHelper;


        public frm_Dept_and_Roles()
        {
            InitializeComponent();
            dbHelper = new db_Helper();
            InitializeListViewDepts();
            InitializeListViewRoles();
            InitializeContextMenuDepts();
            InitializeContextMenuRoles();
            LoadDepartments();
            LoadRoles();
        }

        private void InitializeListViewDepts()
        {
            lstv_depts.View = View.Details;
            lstv_depts.Columns.Add("ID", 50);
            lstv_depts.Columns.Add("Department Name", 150);
        }

        private void InitializeListViewRoles()
        {
            lstv_roles.View = View.Details;
            lstv_roles.Columns.Add("ID", 50);
            lstv_roles.Columns.Add("Role Name", 150);
        }

        private void InitializeContextMenuDepts()
        {
            ContextMenuStrip contextMenuDepts = new ContextMenuStrip();
            ToolStripMenuItem addDeptItem = new ToolStripMenuItem("Додати відділ");
            ToolStripMenuItem editDeptItem = new ToolStripMenuItem("Редагувати відділ");
            ToolStripMenuItem deleteDeptItem = new ToolStripMenuItem("Видалити відділ");

            addDeptItem.Click += AddDeptItem_Click;
            editDeptItem.Click += EditDeptItem_Click;
            deleteDeptItem.Click += DeleteDeptItem_Click;

            contextMenuDepts.Items.Add(addDeptItem);
            contextMenuDepts.Items.Add(editDeptItem);
            contextMenuDepts.Items.Add(deleteDeptItem);

            lstv_depts.ContextMenuStrip = contextMenuDepts;
        }

        private void InitializeContextMenuRoles()
        {
            ContextMenuStrip contextMenuRoles = new ContextMenuStrip();
            ToolStripMenuItem addRoleItem = new ToolStripMenuItem("Додати роль");
            ToolStripMenuItem editRoleItem = new ToolStripMenuItem("Редагувати роль");
            ToolStripMenuItem deleteRoleItem = new ToolStripMenuItem("Видалити роль");

            addRoleItem.Click += AddRoleItem_Click;
            editRoleItem.Click += EditRoleItem_Click;
            deleteRoleItem.Click += DeleteRoleItem_Click;

            contextMenuRoles.Items.Add(addRoleItem);
            contextMenuRoles.Items.Add(editRoleItem);
            contextMenuRoles.Items.Add(deleteRoleItem);

            lstv_roles.ContextMenuStrip = contextMenuRoles;
        }

        private void LoadDepartments()
        {
            dbHelper.LoadDepartments(lstv_depts);
        }

        private void LoadRoles()
        {
            dbHelper.LoadRoles(lstv_roles);
        }

        private void AddDeptItem_Click(object sender, EventArgs e)
        {
            using (var inputDialog = new InputDialog("Додати відділ", "Введіть назву відділу:"))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    dbHelper.AddDepartment(inputDialog.InputText);
                    LoadDepartments();
                }
            }
        }

        private void EditDeptItem_Click(object sender, EventArgs e)
        {
            if (lstv_depts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть відділ для редагування.");
                return;
            }

            var selectedItem = lstv_depts.SelectedItems[0];
            int deptId = int.Parse(selectedItem.SubItems[0].Text);
            string currentName = selectedItem.SubItems[1].Text;

            using (var inputDialog = new InputDialog("Редагувати відділ", "Введіть нову назву відділу:", currentName))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    dbHelper.UpdateDepartment(deptId, inputDialog.InputText);
                    LoadDepartments();
                }
            }
        }

        private void DeleteDeptItem_Click(object sender, EventArgs e)
        {
            if (lstv_depts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть відділ для видалення.");
                return;
            }

            var selectedItem = lstv_depts.SelectedItems[0];
            int deptId = int.Parse(selectedItem.SubItems[0].Text);

            if (MessageBox.Show("Ви впевнені, що хочете видалити цей відділ?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dbHelper.DeleteDepartment(deptId);
                LoadDepartments();
            }
        }

        private void AddRoleItem_Click(object sender, EventArgs e)
        {
            using (var inputDialog = new InputDialog("Додати роль", "Введіть назву ролі:"))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    dbHelper.AddRole(inputDialog.InputText);
                    LoadRoles();
                }
            }
        }

        private void EditRoleItem_Click(object sender, EventArgs e)
        {
            if (lstv_roles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть роль для редагування.");
                return;
            }

            var selectedItem = lstv_roles.SelectedItems[0];
            int roleId = int.Parse(selectedItem.SubItems[0].Text);
            string currentName = selectedItem.SubItems[1].Text;

            using (var inputDialog = new InputDialog("Редагувати роль", "Введіть нову назву ролі:", currentName))
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    dbHelper.UpdateRole(roleId, inputDialog.InputText);
                    LoadRoles();
                }
            }
        }

        private void DeleteRoleItem_Click(object sender, EventArgs e)
        {
            if (lstv_roles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть роль для видалення.");
                return;
            }

            var selectedItem = lstv_roles.SelectedItems[0];
            int roleId = int.Parse(selectedItem.SubItems[0].Text);

            if (MessageBox.Show("Ви впевнені, що хочете видалити цю роль?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dbHelper.DeleteRole(roleId);
                LoadRoles();
            }
        }
        private void lstv_depts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstv_roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
