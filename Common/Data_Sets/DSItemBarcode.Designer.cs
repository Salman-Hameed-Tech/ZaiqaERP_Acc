//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace PointOfSale.Data_Sets {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("DSItemBarcode")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class DSItemBarcode : global::System.Data.DataSet {
        
        private SPItemBarcodeDataTable tableSPItemBarcode;
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public DSItemBarcode() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected DSItemBarcode(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["SPItemBarcode"] != null)) {
                    base.Tables.Add(new SPItemBarcodeDataTable(ds.Tables["SPItemBarcode"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.Browsable(false)]
        [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public SPItemBarcodeDataTable SPItemBarcode {
            get {
                return this.tableSPItemBarcode;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.BrowsableAttribute(true)]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override global::System.Data.DataSet Clone() {
            DSItemBarcode cln = ((DSItemBarcode)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["SPItemBarcode"] != null)) {
                    base.Tables.Add(new SPItemBarcodeDataTable(ds.Tables["SPItemBarcode"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableSPItemBarcode = ((SPItemBarcodeDataTable)(base.Tables["SPItemBarcode"]));
            if ((initTable == true)) {
                if ((this.tableSPItemBarcode != null)) {
                    this.tableSPItemBarcode.InitVars();
                }
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "DSItemBarcode";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSItemBarcode.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableSPItemBarcode = new SPItemBarcodeDataTable();
            base.Tables.Add(this.tableSPItemBarcode);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeSPItemBarcode() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            DSItemBarcode ds = new DSItemBarcode();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace)) {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length)) {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length) 
                                        && (s1.ReadByte() == s2.ReadByte())); ) {
                                ;
                            }
                            if ((s1.Position == s1.Length)) {
                                return type;
                            }
                        }
                    }
                }
                finally {
                    if ((s1 != null)) {
                        s1.Close();
                    }
                    if ((s2 != null)) {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }
        
        public delegate void SPItemBarcodeRowChangeEventHandler(object sender, SPItemBarcodeRowChangeEvent e);
        
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [global::System.Serializable()]
        [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class SPItemBarcodeDataTable : global::System.Data.TypedTableBase<SPItemBarcodeRow> {
            
            private global::System.Data.DataColumn columnItemname;
            
            private global::System.Data.DataColumn columnItemPrice;
            
            private global::System.Data.DataColumn columnItemBarcode;
            
            private global::System.Data.DataColumn columnItemQuantity;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SPItemBarcodeDataTable() {
                this.TableName = "SPItemBarcode";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal SPItemBarcodeDataTable(global::System.Data.DataTable table) {
                this.TableName = table.TableName;
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
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected SPItemBarcodeDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn ItemnameColumn {
                get {
                    return this.columnItemname;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn ItemPriceColumn {
                get {
                    return this.columnItemPrice;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn ItemBarcodeColumn {
                get {
                    return this.columnItemBarcode;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn ItemQuantityColumn {
                get {
                    return this.columnItemQuantity;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SPItemBarcodeRow this[int index] {
                get {
                    return ((SPItemBarcodeRow)(this.Rows[index]));
                }
            }
            
            public event SPItemBarcodeRowChangeEventHandler SPItemBarcodeRowChanging;
            
            public event SPItemBarcodeRowChangeEventHandler SPItemBarcodeRowChanged;
            
            public event SPItemBarcodeRowChangeEventHandler SPItemBarcodeRowDeleting;
            
            public event SPItemBarcodeRowChangeEventHandler SPItemBarcodeRowDeleted;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddSPItemBarcodeRow(SPItemBarcodeRow row) {
                this.Rows.Add(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SPItemBarcodeRow AddSPItemBarcodeRow(string Itemname, string ItemPrice, string ItemBarcode, int ItemQuantity) {
                SPItemBarcodeRow rowSPItemBarcodeRow = ((SPItemBarcodeRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        Itemname,
                        ItemPrice,
                        ItemBarcode,
                        ItemQuantity};
                rowSPItemBarcodeRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowSPItemBarcodeRow);
                return rowSPItemBarcodeRow;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override global::System.Data.DataTable Clone() {
                SPItemBarcodeDataTable cln = ((SPItemBarcodeDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataTable CreateInstance() {
                return new SPItemBarcodeDataTable();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnItemname = base.Columns["Itemname"];
                this.columnItemPrice = base.Columns["ItemPrice"];
                this.columnItemBarcode = base.Columns["ItemBarcode"];
                this.columnItemQuantity = base.Columns["ItemQuantity"];
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnItemname = new global::System.Data.DataColumn("Itemname", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnItemname);
                this.columnItemPrice = new global::System.Data.DataColumn("ItemPrice", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnItemPrice);
                this.columnItemBarcode = new global::System.Data.DataColumn("ItemBarcode", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnItemBarcode);
                this.columnItemQuantity = new global::System.Data.DataColumn("ItemQuantity", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnItemQuantity);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SPItemBarcodeRow NewSPItemBarcodeRow() {
                return ((SPItemBarcodeRow)(this.NewRow()));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder) {
                return new SPItemBarcodeRow(builder);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Type GetRowType() {
                return typeof(SPItemBarcodeRow);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.SPItemBarcodeRowChanged != null)) {
                    this.SPItemBarcodeRowChanged(this, new SPItemBarcodeRowChangeEvent(((SPItemBarcodeRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.SPItemBarcodeRowChanging != null)) {
                    this.SPItemBarcodeRowChanging(this, new SPItemBarcodeRowChangeEvent(((SPItemBarcodeRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.SPItemBarcodeRowDeleted != null)) {
                    this.SPItemBarcodeRowDeleted(this, new SPItemBarcodeRowChangeEvent(((SPItemBarcodeRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.SPItemBarcodeRowDeleting != null)) {
                    this.SPItemBarcodeRowDeleting(this, new SPItemBarcodeRowChangeEvent(((SPItemBarcodeRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveSPItemBarcodeRow(SPItemBarcodeRow row) {
                this.Rows.Remove(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                DSItemBarcode ds = new DSItemBarcode();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "SPItemBarcodeDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace)) {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length)) {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length) 
                                            && (s1.ReadByte() == s2.ReadByte())); ) {
                                    ;
                                }
                                if ((s1.Position == s1.Length)) {
                                    return type;
                                }
                            }
                        }
                    }
                    finally {
                        if ((s1 != null)) {
                            s1.Close();
                        }
                        if ((s2 != null)) {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }
        
        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class SPItemBarcodeRow : global::System.Data.DataRow {
            
            private SPItemBarcodeDataTable tableSPItemBarcode;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal SPItemBarcodeRow(global::System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableSPItemBarcode = ((SPItemBarcodeDataTable)(this.Table));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string Itemname {
                get {
                    try {
                        return ((string)(this[this.tableSPItemBarcode.ItemnameColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'Itemname\' in table \'SPItemBarcode\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSPItemBarcode.ItemnameColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string ItemPrice {
                get {
                    try {
                        return ((string)(this[this.tableSPItemBarcode.ItemPriceColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'ItemPrice\' in table \'SPItemBarcode\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSPItemBarcode.ItemPriceColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string ItemBarcode {
                get {
                    try {
                        return ((string)(this[this.tableSPItemBarcode.ItemBarcodeColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'ItemBarcode\' in table \'SPItemBarcode\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSPItemBarcode.ItemBarcodeColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int ItemQuantity {
                get {
                    try {
                        return ((int)(this[this.tableSPItemBarcode.ItemQuantityColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'ItemQuantity\' in table \'SPItemBarcode\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSPItemBarcode.ItemQuantityColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsItemnameNull() {
                return this.IsNull(this.tableSPItemBarcode.ItemnameColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetItemnameNull() {
                this[this.tableSPItemBarcode.ItemnameColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsItemPriceNull() {
                return this.IsNull(this.tableSPItemBarcode.ItemPriceColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetItemPriceNull() {
                this[this.tableSPItemBarcode.ItemPriceColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsItemBarcodeNull() {
                return this.IsNull(this.tableSPItemBarcode.ItemBarcodeColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetItemBarcodeNull() {
                this[this.tableSPItemBarcode.ItemBarcodeColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsItemQuantityNull() {
                return this.IsNull(this.tableSPItemBarcode.ItemQuantityColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetItemQuantityNull() {
                this[this.tableSPItemBarcode.ItemQuantityColumn] = global::System.Convert.DBNull;
            }
        }
        
        /// <summary>
        ///Row event argument class
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SPItemBarcodeRowChangeEvent : global::System.EventArgs {
            
            private SPItemBarcodeRow eventRow;
            
            private global::System.Data.DataRowAction eventAction;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SPItemBarcodeRowChangeEvent(SPItemBarcodeRow row, global::System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SPItemBarcodeRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591