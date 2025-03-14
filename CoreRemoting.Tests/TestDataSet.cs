//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
//This source code was auto-generated by MonoXSD
//
// Command line to generate:  xsd TestDataSet.xsd /dataset /language:CS
//
#pragma warning disable SYSLIB0051 // Type or member is obsolete
namespace CoreRemoting.Tests;

[System.Serializable()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Diagnostics.DebuggerStepThrough()]
[System.ComponentModel.ToolboxItem(true)]
[System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("TestDataSet")]
public class TestDataSet : System.Data.DataSet {
    
    private TestTableDataTable tableTestTable;
    
    public TestDataSet() {
        this.BeginInit();
        this.InitClass();
        System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
        this.Tables.CollectionChanged += schemaChangedHandler;
        this.Relations.CollectionChanged += schemaChangedHandler;
        this.EndInit();
    }

    protected TestDataSet(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
            base(info, context) {
        if ((this.IsBinarySerialized(info, context) == true)) {
            this.InitVars(false);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler1;
            this.Relations.CollectionChanged += schemaChangedHandler1;
            return;
        }
        string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
        if ((strSchema != null)) {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            if ((ds.Tables["TestTable"] != null)) {
                this.Tables.Add(new TestTableDataTable(ds.Tables["TestTable"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        else {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        this.GetSerializationData(info, context);
        System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
        this.Tables.CollectionChanged += schemaChangedHandler;
        this.Relations.CollectionChanged += schemaChangedHandler;
    }

    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
    public TestTableDataTable TestTable {
        get {
            return this.tableTestTable;
        }
    }
    
    public override System.Data.DataSet Clone() {
        TestDataSet cln = ((TestDataSet)(base.Clone()));
        cln.InitVars();
        return cln;
    }
    
    internal void InitVars() {
        this.InitVars(true);
    }
    
    protected override bool ShouldSerializeTables() {
        return false;
    }
    
    protected override bool ShouldSerializeRelations() {
        return false;
    }
    
    public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs) {
        TestDataSet ds = new TestDataSet();
        xs.Add(ds.GetSchemaSerializable());
        System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
        System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
        System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
        any.Namespace = ds.Namespace;
        sequence.Items.Add(any);
        type.Particle = sequence;
        return type;
    }
    
    protected override void ReadXmlSerializable(System.Xml.XmlReader reader) {
        this.Reset();
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(reader);
        if ((ds.Tables["TestTable"] != null)) {
            this.Tables.Add(new TestTableDataTable(ds.Tables["TestTable"]));
        }
        this.DataSetName = ds.DataSetName;
        this.Prefix = ds.Prefix;
        this.Namespace = ds.Namespace;
        this.Locale = ds.Locale;
        this.CaseSensitive = ds.CaseSensitive;
        this.EnforceConstraints = ds.EnforceConstraints;
        this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
        this.InitVars();
    }
    
    protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
        System.IO.MemoryStream stream = new System.IO.MemoryStream();
        this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
        stream.Position = 0;
        return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
    }
    
    internal void InitVars(bool initTable) {
        this.tableTestTable = ((TestTableDataTable)(this.Tables["TestTable"]));
        if ((initTable == true)) {
            if ((this.tableTestTable != null)) {
                this.tableTestTable.InitVars();
            }
        }
    }
    
    private void InitClass() {
        this.DataSetName = "TestDataSet";
        this.Prefix = "";
        this.Namespace = "";
        this.Locale = new System.Globalization.CultureInfo("de-DE");
        this.CaseSensitive = false;
        this.EnforceConstraints = true;
        this.tableTestTable = new TestTableDataTable();
        this.Tables.Add(this.tableTestTable);
    }
    
    private bool ShouldSerializeTestTable() {
        return false;
    }
    
    private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
        if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
            this.InitVars();
        }
    }
    
    public delegate void TestTableRowChangeEventHandler(object sender, TestTableRowChangeEvent e);
    
    [System.Serializable()]
    [System.Diagnostics.DebuggerStepThrough()]
    public class TestTableDataTable : System.Data.DataTable, System.Collections.IEnumerable {
        
        private System.Data.DataColumn columnUserName;
        
        private System.Data.DataColumn columnAge;
        
        public TestTableDataTable() : 
                base("TestTable") {
            this.InitClass();
        }
        
        protected TestTableDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context) {
            this.InitVars();
        }
        
        internal TestTableDataTable(System.Data.DataTable table) : 
                base(table.TableName) {
            if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                this.CaseSensitive = table.CaseSensitive;
            }
            if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                this.Locale = table.Locale;
            }
            if ((table.Namespace != table.DataSet.Namespace)) {
                this.Namespace = table.Namespace;
            }
            this.Prefix = table.Prefix;
            this.MinimumCapacity = table.MinimumCapacity;
            this.DisplayExpression = table.DisplayExpression;
        }
        
        [System.ComponentModel.Browsable(false)]
        public int Count {
            get {
                return this.Rows.Count;
            }
        }
        
        public System.Data.DataColumn UserNameColumn {
            get {
                return this.columnUserName;
            }
        }
        
        public System.Data.DataColumn AgeColumn {
            get {
                return this.columnAge;
            }
        }
        
        public TestTableRow this[int index] {
            get {
                return ((TestTableRow)(this.Rows[index]));
            }
        }
        
        public event TestTableRowChangeEventHandler TestTableRowChanged;
        
        public event TestTableRowChangeEventHandler TestTableRowChanging;
        
        public event TestTableRowChangeEventHandler TestTableRowDeleted;
        
        public event TestTableRowChangeEventHandler TestTableRowDeleting;
        
        public void AddTestTableRow(TestTableRow row) {
            this.Rows.Add(row);
        }
        
        public TestTableRow AddTestTableRow(string UserName, short Age) {
            TestTableRow rowTestTableRow = ((TestTableRow)(this.NewRow()));
            rowTestTableRow.ItemArray = new object[] {
                    UserName,
                    Age};
            this.Rows.Add(rowTestTableRow);
            return rowTestTableRow;
        }
        
        public System.Collections.IEnumerator GetEnumerator() {
            return this.Rows.GetEnumerator();
        }
        
        public override System.Data.DataTable Clone() {
            TestTableDataTable cln = ((TestTableDataTable)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override System.Data.DataTable CreateInstance() {
            return new TestTableDataTable();
        }
        
        internal void InitVars() {
            this.columnUserName = this.Columns["UserName"];
            this.columnAge = this.Columns["Age"];
        }
        
        private void InitClass() {
            this.columnUserName = new System.Data.DataColumn("UserName", typeof(string), null, System.Data.MappingType.Element);
            this.Columns.Add(this.columnUserName);
            this.columnAge = new System.Data.DataColumn("Age", typeof(short), null, System.Data.MappingType.Element);
            this.Columns.Add(this.columnAge);
        }
        
        public TestTableRow NewTestTableRow() {
            return ((TestTableRow)(this.NewRow()));
        }
        
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
            return new TestTableRow(builder);
        }
        
        protected override System.Type GetRowType() {
            return typeof(TestTableRow);
        }
        
        protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
            base.OnRowChanged(e);
            if ((this.TestTableRowChanged != null)) {
                this.TestTableRowChanged(this, new TestTableRowChangeEvent(((TestTableRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
            base.OnRowChanging(e);
            if ((this.TestTableRowChanging != null)) {
                this.TestTableRowChanging(this, new TestTableRowChangeEvent(((TestTableRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
            base.OnRowDeleted(e);
            if ((this.TestTableRowDeleted != null)) {
                this.TestTableRowDeleted(this, new TestTableRowChangeEvent(((TestTableRow)(e.Row)), e.Action));
            }
        }
        
        protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
            base.OnRowDeleting(e);
            if ((this.TestTableRowDeleting != null)) {
                this.TestTableRowDeleting(this, new TestTableRowChangeEvent(((TestTableRow)(e.Row)), e.Action));
            }
        }
        
        public void RemoveTestTableRow(TestTableRow row) {
            this.Rows.Remove(row);
        }
    }
    
    [System.Diagnostics.DebuggerStepThrough()]
    public class TestTableRow : System.Data.DataRow {
        
        private TestTableDataTable tableTestTable;
        
        internal TestTableRow(System.Data.DataRowBuilder rb) : 
                base(rb) {
            this.tableTestTable = ((TestTableDataTable)(this.Table));
        }
        
        public string UserName {
            get {
                try {
                    return ((string)(this[this.tableTestTable.UserNameColumn]));
                }
                catch (System.InvalidCastException e) {
                    throw new System.Data.StrongTypingException("StrongTyping_CananotAccessDBNull", e);
                }
            }
            set {
                this[this.tableTestTable.UserNameColumn] = value;
            }
        }
        
        public short Age {
            get {
                try {
                    return ((short)(this[this.tableTestTable.AgeColumn]));
                }
                catch (System.InvalidCastException e) {
                    throw new System.Data.StrongTypingException("StrongTyping_CananotAccessDBNull", e);
                }
            }
            set {
                this[this.tableTestTable.AgeColumn] = value;
            }
        }
        
        public bool IsUserNameNull() {
            return this.IsNull(this.tableTestTable.UserNameColumn);
        }
        
        public void SetUserNameNull() {
            this[this.tableTestTable.UserNameColumn] = System.Convert.DBNull;
        }
        
        public bool IsAgeNull() {
            return this.IsNull(this.tableTestTable.AgeColumn);
        }
        
        public void SetAgeNull() {
            this[this.tableTestTable.AgeColumn] = System.Convert.DBNull;
        }
    }
    
    [System.Diagnostics.DebuggerStepThrough()]
    public class TestTableRowChangeEvent : System.EventArgs {
        
        private TestTableRow eventRow;
        
        private System.Data.DataRowAction eventAction;
        
        public TestTableRowChangeEvent(TestTableRow row, System.Data.DataRowAction action) {
            this.eventRow = row;
            this.eventAction = action;
        }
        
        public TestTableRow Row {
            get {
                return this.eventRow;
            }
        }
        
        public System.Data.DataRowAction Action {
            get {
                return this.eventAction;
            }
        }
    }
}
#pragma warning restore SYSLIB0051 // Type or member is obsolete
