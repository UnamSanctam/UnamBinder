using System;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;
using System.Collections.Generic;

namespace FormSerialisation
{
    public static class FormSerializer
    {

        /* Form Serializer by Unam Sanctam https://github.com/UnamSanctam, based on http://www.codeproject.com/KB/dialog/SavingTheStateOfAForm.aspx */

        public static void Serialise(List<Control> cntrls, string XmlFileName)
        {
            XmlTextWriter xmlSerialisedForm = new XmlTextWriter(XmlFileName, System.Text.Encoding.Default);
            xmlSerialisedForm.Formatting = Formatting.Indented;
            xmlSerialisedForm.WriteStartDocument();
            xmlSerialisedForm.WriteStartElement("Form");
            foreach (Control c in cntrls)
            {
                AddChildControls(xmlSerialisedForm, c);
            }
            xmlSerialisedForm.WriteEndElement();
            xmlSerialisedForm.WriteEndDocument();
            xmlSerialisedForm.Flush();
            xmlSerialisedForm.Close();
        }

        private static void AddChildControls(XmlTextWriter xmlSerialisedForm, Control c)
        {
            foreach (Control childCtrl in c.Controls)
            {
                if (!(childCtrl is Label) && !string.IsNullOrEmpty(childCtrl.Name))
                {
                    xmlSerialisedForm.WriteStartElement("Control");
                    xmlSerialisedForm.WriteAttributeString("Type", childCtrl.GetType().ToString());
                    xmlSerialisedForm.WriteAttributeString("Name", childCtrl.Name);
                    if (childCtrl is MephTextBox)
                    {
                        xmlSerialisedForm.WriteElementString("Text", ((MephTextBox)childCtrl).Text);
                    }
                    else if (childCtrl is MephComboBox)
                    {
                        xmlSerialisedForm.WriteElementString("Text", ((MephComboBox)childCtrl).Text);
                        xmlSerialisedForm.WriteElementString("SelectedIndex", ((MephComboBox)childCtrl).SelectedIndex.ToString());
                    }
                    else if (childCtrl is MephListBox)
                    {
                        MephListBox lst = (MephListBox)childCtrl;
                        for (int i = 0; i < lst.Items.Count; i++)
                        {
                            xmlSerialisedForm.WriteStartElement("Item");
                            xmlSerialisedForm.WriteAttributeString("Type", lst.Items[i].GetType().ToString());
                            AddChildControls(xmlSerialisedForm, (Control)lst.Items[i]);
                            xmlSerialisedForm.WriteEndElement();
                        }
                    }
                    else if (childCtrl is MephCheckBox)
                    {
                        xmlSerialisedForm.WriteElementString("Text", ((MephCheckBox)childCtrl).Text);
                        xmlSerialisedForm.WriteElementString("Checked", ((MephCheckBox)childCtrl).Checked.ToString());
                    }
                    else if (childCtrl is MephToggleSwitch)
                    {
                        xmlSerialisedForm.WriteElementString("Text", ((MephToggleSwitch)childCtrl).Text);
                        xmlSerialisedForm.WriteElementString("Checked", ((MephToggleSwitch)childCtrl).Checked.ToString());
                    }
                    bool visible = (bool)typeof(Control).GetMethod("GetState", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(childCtrl, new object[] { 2 });
                    xmlSerialisedForm.WriteElementString("Visible", visible.ToString());
                    xmlSerialisedForm.WriteElementString("Enabled", childCtrl.Enabled.ToString());
                    if (childCtrl.HasChildren)
                    {
                        if (childCtrl is SplitContainer)
                        {
                            AddChildControls(xmlSerialisedForm, ((SplitContainer)childCtrl).Panel1);
                            AddChildControls(xmlSerialisedForm, ((SplitContainer)childCtrl).Panel2);
                        }
                        else
                        {
                            AddChildControls(xmlSerialisedForm, childCtrl);
                        }
                    }
                    xmlSerialisedForm.WriteEndElement();
                }
            }
        }

        public static void Deserialise(List<Control> cntrls, string XmlFileName)
        {
            if (File.Exists(XmlFileName))
            {
                XmlDocument xmlSerialisedForm = new XmlDocument();
                xmlSerialisedForm.Load(XmlFileName);
                XmlNode topLevel = xmlSerialisedForm.ChildNodes[1];
                foreach (XmlNode n in topLevel.ChildNodes)
                {
                    foreach (Control c in cntrls)
                    {
                        SetControlProperties(c, n);
                    }
                }
            }
        }

        private static void SetControlProperties(Control currentCtrl, XmlNode n)
        {
            string controlName = n.Attributes["Name"].Value;
            string controlType = n.Attributes["Type"].Value;
            Control[] ctrl = currentCtrl.Controls.Find(controlName, true);
            if (ctrl.Length > 0)
            {
                Control ctrlToSet = GetImmediateChildControl(ctrl, currentCtrl);
                if (ctrlToSet != null)
                {
                    if (ctrlToSet.GetType().ToString() == controlType)
                    {
                        switch (controlType)
                        {
                            case "MephTextBox":
                                ((MephTextBox)ctrlToSet).Text = n["Text"].InnerText;
                                break;
                            case "MephComboBox":
                                ((MephComboBox)ctrlToSet).Text = n["Text"].InnerText;
                                ((MephComboBox)ctrlToSet).SelectedIndex = Convert.ToInt32(n["SelectedIndex"].InnerText);
                                break;
                            case "MephListBox":
                                MephListBox lst = (MephListBox)ctrlToSet;
                                lst.Items.Clear();
                                XmlNodeList xnlControls = n.SelectNodes("Item");
                                foreach (XmlNode n2 in xnlControls)
                                {
                                    dynamic item = Activator.CreateInstance(Type.GetType(n2.Attributes["Type"].Value));
                                    lst.Items.Add(item);
                                    foreach (XmlNode n3 in n2.ChildNodes)
                                    {
                                        int count = lst.Items.Count;
                                        SetControlProperties((Control)lst.Items[count - 1], n3);
                                        for (int i = 0; i < count; i++)
                                        {
                                            lst.Items[i] = lst.Items[i];
                                        }
                                    }
                                }
                                break;
                            case "MephCheckBox":
                                ((MephCheckBox)ctrlToSet).Text = n["Text"].InnerText;
                                ((MephCheckBox)ctrlToSet).Checked = Convert.ToBoolean(n["Checked"].InnerText);
                                break;
                            case "MephToggleSwitch":
                                ((MephToggleSwitch)ctrlToSet).Text = n["Text"].InnerText;
                                ((MephToggleSwitch)ctrlToSet).Checked = Convert.ToBoolean(n["Checked"].InnerText);
                                break;
                        }
                        ctrlToSet.Visible = Convert.ToBoolean(n["Visible"].InnerText);
                        ctrlToSet.Enabled = Convert.ToBoolean(n["Enabled"].InnerText);
                        if (n.HasChildNodes && ctrlToSet.HasChildren)
                        {
                            XmlNodeList xnlControls = n.SelectNodes("Control");
                            foreach (XmlNode n2 in xnlControls)
                            {
                                SetControlProperties(ctrlToSet, n2);
                            }
                        }
                    }
                }
            }
        }

        private static Control GetImmediateChildControl(Control[] ctrl, Control currentCtrl)
        {
            Control c = null;
            for (int i = 0; i < ctrl.Length; i++)
            {
                if ((ctrl[i].Parent.Name == currentCtrl.Name) || (currentCtrl is SplitContainer && ctrl[i].Parent.Parent.Name == currentCtrl.Name))
                {
                    c = ctrl[i];
                    break;
                }
            }
            return c;
        }

    }
}
