using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridViewHelper
{
    /// <summary>
    /// 定义表格数据显示的内容
    /// </summary>
    public class TableDataOption
    {
        //是否显示编辑按钮
        private bool showEditButton = true;

        public bool ShowEditButton
        {
            get { return showEditButton; }
            set { showEditButton = value; }
        }
        //是否显示删除按钮
        private bool showDeleteButton = true;

        public bool ShowDeleteButton
        {
            get { return showDeleteButton; }
            set { showDeleteButton = value; }
        }
        //编辑按钮文本
        private string editButtonText = "编辑";

        public string EditButtonText
        {
            get { return editButtonText; }
            set { editButtonText = value; }
        }
        //删除按钮文本
        private string deleteButtonText = "删除";

        public string DeleteButtonText
        {
            get { return deleteButtonText; }
            set { deleteButtonText = value; }
        }       
        //点击编辑后的动作
        private string editAction = "Edit";

        public string EditAction
        {
            get { return editAction; }
            set { editAction = value; }
        }
        //点击删除后的动作
        private string deleteAction = "Delete";

        public string DeleteAction
        {
            get { return deleteAction; }
            set { deleteAction = value; }
        }
        //表格数据显示的标头
        private string[] columns;

        public string[] Columns
        {
            get { return columns; }
            set { columns = value; }
        }



    }
}
