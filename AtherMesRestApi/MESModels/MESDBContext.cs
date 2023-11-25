using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AtherMesRestApi.MESModels
{
    public partial class MESDBContext : DbContext
    {


        public MESDBContext(DbContextOptions<MESDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SapProductionOrder> SapProductionOrder { get; set; }
        public virtual DbSet<SapProductionKeyComponents> SapProductionKeyComponents { get; set; }
        public virtual DbSet<UserSkill> UserSkill { get; set; }

        public virtual DbSet<StatusGenealogy> StatusGenealogy { get; set; }
        public virtual DbSet<PreviousStation> PreviousStation { get; set; }
        public virtual DbSet<CallLogModel> CallLog { get; set; }
        public virtual DbSet<UpdateGoogleChat> GoogleChat { get; set; }
        public virtual DbSet<MobileTerminalConfig> MobileTerminalConfig { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<BinList> BinList { get; set; }
        public virtual DbSet<BinListCommon> BinListCommon { get; set; }
        public virtual DbSet<CheckPoint> CheckPoint { get; set; }

        public virtual DbSet<CheckPoints> CheckPoints { get; set; }
        public virtual DbSet<PMCheckPoint> PMCheckPoint { get; set; }
        public virtual DbSet<CheckList> CheckList { get; set; }
        public virtual DbSet<SAP_Mileston_Response> SAP_Mileston_Response { get; set; }
        public virtual DbSet<ShiftInformation> ShiftInformation { get; set; }
        public virtual DbSet<PMCheckList> PMCheckList { get; set; }
        public virtual DbSet<JHCheckList> JHCheckList { get; set; }
        public virtual DbSet<Config_JHCheckPoint> Config_JHCheckPoint { get; set; }
        public virtual DbSet<Prod_Execute_JHCheckList> Prod_Execute_JHCheckList { get; set; }
        public virtual DbSet<GeneologyProd> GeneologyProd { get; set; }
        public virtual DbSet<Prod_B_GenealogyFG> Prod_B_GenealogyFG { get; set; }
        public virtual DbSet<Prod_B_GenealogyHistory> Prod_B_GenealogyHistory { get; set; }
        public virtual DbSet<Prod_BatteryGeneologyKepWare> Prod_BatteryGeneologyKepWare { get; set; }
        public virtual DbSet<Prod_CyclerTemptable> Prod_CyclerTemptable { get; set; }
        public virtual DbSet<Prod_StationGeneology> Prod_StationGeneology { get; set; }
        public virtual DbSet<BugListConfig> BugListConfig { get; set; }
        public virtual DbSet<DHCParameters> DHCParameters { get; set; }
        public virtual DbSet<StationParameter> StationParameter { get; set; }
        public virtual DbSet<StationMaster> StationMaster { get; set; }
        public virtual DbSet<Config_User> Config_User { get; set; }
        public virtual DbSet<v_Config_User_Common> v_Config_User_Common { get; set; }
        public virtual DbSet<v_SAP_B_PROD_ORDER> v_SAP_B_PROD_ORDER { get; set; }
        public virtual DbSet<ReworkWIP> ReworkWIP { get; set; }
        public virtual DbSet<BatteryDetailsGeneology> BatteryDetailsGeneology { get; set; }
        public virtual DbSet<BatteryDetailsRejection> BatteryDetailsRejection { get; set; }
        public virtual DbSet<Quality_DHCRejection_WIPCommon> Quality_DHCRejection_WIPCommon { get; set; }
        public virtual DbSet<BatteryWIP> BatteryWIP { get; set; }
        public virtual DbSet<Prod_B_WIPFG> Prod_B_WIPFG { get; set; }
        public virtual DbSet<Prod_B_WIPHistory> Prod_B_WIPHistory { get; set; }
        public virtual DbSet<Prod_BatteryWIPLineCommon> Prod_BatteryWIPLineCommon { get; set; }
        public virtual DbSet<Config_LineUserAssigment> Config_LineUserAssigment { get; set; }
        public virtual DbSet<Config_UserAssigment> Config_UserAssigment { get; set; }
        public virtual DbSet<Pref_SPRLoss> Pref_SPRLoss { get; set; }
        public virtual DbSet<GetBatteryDetails> GetBatteryDetails { get; set; }
        public virtual DbSet<GetBatteryDetailsCommon> GetBatteryDetailsCommon { get; set; }
        public virtual DbSet<IPQCSaveClose> IPQCSaveClose { get; set; }
        public virtual DbSet<MesCompelete> MesCompelete { get; set; }
        public virtual DbSet<LoggedUser> LoggedUser { get; set; }
        public virtual DbSet<Prod_LoggedUser> Prod_LoggedUser { get; set; }
        public virtual DbSet<PMSaveClose> PMSaveClose { get; set; }
        public virtual DbSet<Config_IPQCSchedule> Config_IPQCSchedule { get; set; }
        public virtual DbSet<Config_JHSchedule> Config_JHSchedule { get; set; }
        public virtual DbSet<Quality_History_IPQCCheckList> Quality_History_IPQCCheckList { get; set; }
        public virtual DbSet<Maint_History_PMCheckList> Maint_History_PMCheckList { get; set; }
        public virtual DbSet<Prod_History_JHCheckList> Prod_History_JHCheckList { get; set; }
        public virtual DbSet<Maint_Breakdown_Log> Maint_Breakdown_Log { get; set; }
        public virtual DbSet<v_Maint_Breakdown_Log> v_Maint_Breakdown_Log { get; set; }
        public virtual DbSet<Config_PMSchedule> Config_PMSchedule { get; set; }
        public virtual DbSet<JIRA_Send_Data> JIRA_Send_Data { get; set; }
        public virtual DbSet<Prod_ProductionExecution> Prod_ProductionExecution { get; set; }
        public virtual DbSet<SAP_KEY_COMPONENT_BOOKING> SAP_KEY_COMPONENT_BOOKING { get; set; }
        public virtual DbSet<Prod_MESProductionPlan> Prod_MESProductionPlan { get; set; }
        public virtual DbSet<output> output { get; set; }
        public virtual DbSet<Prod_ReworkGeneology> Prod_ReworkGeneology { get; set; }
        public virtual DbSet<Quality_DHCImage> Quality_DHCImage { get; set; }
        public virtual DbSet<Config_Instance> Config_Instance { get; set; }
        public virtual DbSet<Config_Instance_PM> Config_Instance_PM { get; set; }
        public virtual DbSet<SAP_JIRA_Response> SAP_JIRA_Response { get; set; }
        public virtual DbSet<BMS_PCBRevisionControl> BMS_PCBRevisionControl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SapProductionOrder>(entity =>
            {
                entity.HasKey(e => e.Production_Order_No)
                .HasName("PK_SAP_Production_Order");

                entity.ToTable("SAP_B_Prod_Order");

                entity.Property(e => e.Production_Order_No)
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.SKU)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.SKU_Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKU_Description");

                entity.Property(e => e.Prod_Date)
                    .HasColumnName("Prod_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Prod_Shift)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("Prod_Shift");

                entity.Property(e => e.Line_No).HasColumnName("Line_No");

                entity.Property(e => e.Order_Quantity).HasColumnName("Order_Quantity");

                entity.Property(e => e.Cell_Type)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasColumnName("Cell_Type");

                entity.Property(e => e.UOM)
               .HasMaxLength(20)
               .IsUnicode(false)
               .HasColumnName("UOM");


                entity.Property(e => e.Serial_No)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasColumnName("Serial_No");

                entity.Property(e => e.Status).HasColumnName("Status");
            });

            modelBuilder.Entity<SapProductionKeyComponents>(entity =>
            {
                entity.HasKey(e => e.Production_Order_Key_Component_Key)
                .HasName("Production_Order_Key_Component_Key");

                entity.ToTable("SAP_B_PROD_ORDER_KEY_COMP");

                entity.Property(e => e.Production_Order_Key_Component_Key)
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.Production_Order_No)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Production_Order_No");

                entity.Property(e => e.Key_Component)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Key_Component");


                entity.Property(e => e.Key_Component_Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Key_Component_Description");



                entity.Property(e => e.Key_Component_Type)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("Key_Component_Type");

            });

            modelBuilder.Entity<output>().HasNoKey();

            modelBuilder.Entity<MobileTerminalConfig>(entity =>

            {
                entity.HasNoKey();


                entity.ToView("v_MobileTerminal");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DeviceId");

                entity.Property(e => e.IMEI_Number)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMEI Number");

                entity.Property(e => e.MACAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MACAddress");

                entity.Property(e => e.StaticIP)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("StaticIP");

                entity.Property(e => e.LineID)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("LineID");

                entity.Property(e => e.StationName)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("StationName");

                entity.Property(e => e.DeviceDescription)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("DeviceDescription");

                entity.Property(e => e.Status)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.Property(e => e.Type)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Type");

                entity.Property(e => e.CreatedOn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CreatedOn");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CreatedBy");

                entity.Property(e => e.lastUpdatedOn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("lastUpdatedOn");

                entity.Property(e => e.lastUpdatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("lastUpdatedBy");

                entity.Property(e => e.ReworkStation)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ReworkStation");


            });

            modelBuilder.Entity<SubCategory>(entity =>

            {
                entity.HasNoKey();


                entity.ToView("Config_DHCNOKSubCategory");

                entity.Property(e => e.Category_ID)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Category_ID");

                entity.Property(e => e.SubCategory_ID)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory_ID");

                entity.Property(e => e.SubCategory_Name)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory_Name");

                entity.Property(e => e.SubCategory_Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory_Description");

                entity.Property(e => e.CreatedOn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CreatedOn");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CreatedBy");

                entity.Property(e => e.LastUpdatedOn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedOn");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedBy");

            });

            modelBuilder.Entity<Category>(entity =>

            {
                entity.HasNoKey();


                entity.ToView("Config_DHCNOKCategory");

                entity.Property(e => e.Category_ID)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Category_ID");

                entity.Property(e => e.Category_Name)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Category_Name");

                entity.Property(e => e.Category_Description)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Category_Description");

                entity.Property(e => e.CreatedOn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CreatedOn");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CreatedBy");

                entity.Property(e => e.LastUpdatedOn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedOn");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedBy");

            });

            modelBuilder.Entity<BinList>(entity =>

            {
                entity.HasNoKey();


                entity.ToView("v_BinList");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.Status)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.Property(e => e.SaveFlag)
                    .IsUnicode(false)
                    .HasColumnName("SaveFlag");

                entity.Property(e => e.EndTime)
                    .IsUnicode(false)
                    .HasColumnName("EndTime");
            });

            modelBuilder.Entity<BinListCommon>(entity =>

            {
                entity.HasNoKey();


                entity.ToView("v_BinListCommon");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.Status)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.Property(e => e.SaveFlag)
                    .IsUnicode(false)
                    .HasColumnName("SaveFlag");

                entity.Property(e => e.ReworkStationName)
                    .IsUnicode(false)
                    .HasColumnName("ReworkStationName");

                entity.Property(e => e.EndTime)
                   .IsUnicode(false)
                   .HasColumnName("EndTime");

            });

            modelBuilder.Entity<GeneologyProd>(entity =>

            {
                entity.HasNoKey();


                entity.ToView("v_BatteryGeneology");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Timestamp");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.StationName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("StationName");

                entity.Property(e => e.ParameterId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterVal)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("ParameterVal");

                entity.Property(e => e.Quality)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("Quality");

                entity.Property(e => e.Status)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Status");
            });

            modelBuilder.Entity<Prod_BatteryGeneologyKepWare>(entity =>

            {
                entity.HasNoKey();


                entity.ToView("v_BatteryGeneologyKepWare");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Timestamp");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.StationName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("StationName");

                entity.Property(e => e.ParameterId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterVal)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("ParameterVal");

                entity.Property(e => e.Quality)
                   .HasMaxLength(500)
                   .IsUnicode(false)
                   .HasColumnName("Quality");

                entity.Property(e => e.Status)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Status");
            });

            modelBuilder.Entity<BugListConfig>(entity =>

            {
                entity.HasNoKey();


                entity.ToTable("Config_DHC_BugList");

                entity.Property(e => e.Bug_ID)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Bug_ID");

                entity.Property(e => e.Bug_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Bug_Name");

                entity.Property(e => e.Bug_Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Bug_Description");

                entity.Property(e => e.CreatedOn)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CreatedOn");

                entity.Property(e => e.CreatedBy)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .HasColumnName("CreatedBy");

                entity.Property(e => e.LastUpdatedOn)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("LastUpdatedOn");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedBy");

            });

            modelBuilder.Entity<DHCParameters>(entity =>

            {
                entity.HasNoKey();

                entity.ToTable("Config_DHCParameters");

                entity.Property(e => e.ParameterId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ParameterDescription");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.EstimatedDuration)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EstimatedDuration");

                entity.Property(e => e.LowerLimit)
                   .IsUnicode(false)
                   .HasColumnName("LowerLimit");

                entity.Property(e => e.UpperLimit)
                   .IsUnicode(false)
                   .HasColumnName("UpperLimit");

                entity.Property(e => e.UOM)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UOM");

                entity.Property(e => e.CheckPointType)
                     .IsUnicode(false)
                     .HasColumnName("CheckPointType");

                entity.Property(e => e.Criticality)
                    .IsUnicode(false)
                    .HasColumnName("Criticality");

                entity.Property(e => e.SKU)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.CreatedOn)
                    .IsUnicode(false)
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CreatedBy");

                entity.Property(e => e.LastUpdatedOn)
                    .IsUnicode(false)
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedBy");

                entity.Property(e => e.LineId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LineId");

                entity.Property(e => e.StationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("StationId");
            });

            modelBuilder.Entity<StationParameter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_StationParameter");

                entity.Property(e => e.ParameterId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ParameterDescription");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.SequenceNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SequenceNo");

                entity.Property(e => e.EstimatedDuration)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("EstimatedDuration");

                entity.Property(e => e.LowerLimit)
                   .IsUnicode(false)
                   .HasColumnName("LowerLimit");

                entity.Property(e => e.UpperLimit)
                   .IsUnicode(false)
                   .HasColumnName("UpperLimit");

                entity.Property(e => e.UOM)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UOM");

                entity.Property(e => e.CheckPointType)
                     .IsUnicode(false)
                     .HasColumnName("CheckPointType");

                entity.Property(e => e.Criticality)
                    .IsUnicode(false)
                    .HasColumnName("Criticality");

                entity.Property(e => e.SKU)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.CreatedOn)
                    .IsUnicode(false)
                    .HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CreatedBy");

                entity.Property(e => e.LastUpdatedOn)
                    .IsUnicode(false)
                    .HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedBy");

                entity.Property(e => e.StationName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("StationName");
            });

            modelBuilder.Entity<StationMaster>(entity =>

            {
                entity.HasKey(e => e.StationId);

                entity.ToTable("Config_Station");

                entity.Property(e => e.LineId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("LineId");

                entity.Property(e => e.StationId)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("StationId");

                entity.Property(e => e.StationName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("StationName");

                entity.Property(e => e.StationTaktTime)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("StationTaktTime");

                entity.Property(e => e.StationDescription)
                   .IsUnicode(false)
                   .HasColumnName("StationDescription");

                entity.Property(e => e.CreatedOn)
                   .IsUnicode(false)
                   .HasColumnName("CreatedOn");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CreatedBy");

                entity.Property(e => e.LastUpdatedOn)
                     .IsUnicode(false)
                     .HasColumnName("LastUpdatedOn");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedBy");


            });

            modelBuilder.Entity<PreviousStation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_PreviousStation");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DeviceId");
                entity.Property(e => e.Station1)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station1");
                entity.Property(e => e.Station2)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station2");
                entity.Property(e => e.Station3)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station3");
                entity.Property(e => e.Station4)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station4");
                entity.Property(e => e.Station5)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station5");
                entity.Property(e => e.Station6)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station6");
                entity.Property(e => e.Station7)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station7");
                entity.Property(e => e.Station8)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station8");
                entity.Property(e => e.Station9)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station9");
                entity.Property(e => e.Station10)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Station10");


            });

            modelBuilder.Entity<UpdateGoogleChat>(entity =>
            {
                entity.HasKey(e => e.RowID);

                entity.ToTable("Google_Chat_Table");

                entity.Property(e => e.RowID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowID");
                entity.Property(e => e.Timestamp)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Timestamp");
                entity.Property(e => e.Msg_Type)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Msg_Type");
                entity.Property(e => e.Line_No)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Line_No");
                entity.Property(e => e.StationName)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("StationName");
                entity.Property(e => e.Assetid)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Assetid");
                entity.Property(e => e.Severity)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Severity");
                entity.Property(e => e.Message)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Message");
                entity.Property(e => e.MSGStatus)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("MSGStatus");

            });

            modelBuilder.Entity<CallLogModel>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("Prod_Supervisor_Call_Log");

                entity.Property(e => e.RowId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowId");
                entity.Property(e => e.LineID)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("LineID");
                entity.Property(e => e.StationID)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("StationID");
                entity.Property(e => e.StartTime)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("StartTime");
                entity.Property(e => e.ACKTime)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ACKTime");
                entity.Property(e => e.EndTime)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("EndTime");
                entity.Property(e => e.CallStatus)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CallStatus");

            });

            modelBuilder.Entity<ReworkWIP>(entity =>
            {
                entity.HasKey(e => e.Line);


                entity.ToTable("DHC_ReworkWIP");

                entity.Property(e => e.Line)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Line");

                entity.Property(e => e.Station)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Station");

                entity.Property(e => e.Operation)
                    .IsUnicode(false)
                    .HasColumnName("Operation");

                entity.Property(e => e.OkNotOk)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .HasColumnName("OkNotOk");

                entity.Property(e => e.Category)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .HasColumnName("Category");

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Description");

                entity.Property(e => e.QualityDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QualityDescription");

                entity.Property(e => e.Shift)
                    .IsUnicode(false)
                    .HasColumnName("Shift");

                entity.Property(e => e.Operator)
                    .IsUnicode(false)
                    .HasColumnName("Operator");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Timestamp");


            });

            modelBuilder.Entity<BatteryDetailsGeneology>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("Prod_BatteryGeneology");

                entity.Property(e => e.ID)
                    .IsUnicode(false)
                    .HasColumnName("ID");


                entity.Property(e => e.Timestamp)
                    .IsUnicode(false)
                    .HasColumnName("Timestamp");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.StationId)
                    .IsUnicode(false)
                    .HasColumnName("StationId");

                entity.Property(e => e.ParameterId)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterVal)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .HasColumnName("ParameterVal");

                entity.Property(e => e.Quality)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Quality");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Status");
            });

            modelBuilder.Entity<BatteryDetailsRejection>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("Quality_DHCRejection_WIP");

                entity.Property(e => e.RowId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowId");

                entity.Property(e => e.ParameterId)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterVal)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .HasColumnName("ParameterVal");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.StationId)
                    .IsUnicode(false)
                    .HasColumnName("StationId");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory");

                entity.Property(e => e.OperatorRemark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OperatorRemark");

                entity.Property(e => e.BUGId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BUGId");

                entity.Property(e => e.QIRemarks)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QIRemarks");

                entity.Property(e => e.RSARemark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RSARemark");
                entity.Property(e => e.PartChangeFlag)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PartChangeFlag");
                entity.Property(e => e.SKUChangeFlag)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SKUChangeFlag");
                entity.Property(e => e.ReworkRemark)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("ReworkRemark");
                entity.Property(e => e.LineId)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("LineId");
            });

            modelBuilder.Entity<RejectionWIP>(entity =>

            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("v_RejectionWIP");

                entity.Property(e => e.RowId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowId");

                entity.Property(e => e.ParameterId)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterVal)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .HasColumnName("ParameterVal");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.StationId)
                    .IsUnicode(false)
                    .HasColumnName("StationId");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory");

                entity.Property(e => e.OperatorRemark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OperatorRemark");

                entity.Property(e => e.BUGId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BUGId");

                entity.Property(e => e.QIRemarks)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QIRemarks");

                entity.Property(e => e.RSARemark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RSARemark");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Status");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_UserLogin");

                entity.Property(e => e.StationId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("StationId");

                entity.Property(e => e.StationName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("StationName");

                entity.Property(e => e.UserID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .HasColumnName("Username");

                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .HasColumnName("Username");

            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_UserSkill");

                entity.Property(e => e.UserID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserName");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserRole");

                entity.Property(e => e.OP10)
                    .IsUnicode(false)
                    .HasColumnName("OP10");

                entity.Property(e => e.OP20)
                    .IsUnicode(false)
                    .HasColumnName("OP20");

                entity.Property(e => e.OP25)
                    .IsUnicode(false)
                    .HasColumnName("OP25");

                entity.Property(e => e.OP30)
                    .IsUnicode(false)
                    .HasColumnName("OP30");

                entity.Property(e => e.OP40)
                    .IsUnicode(false)
                    .HasColumnName("OP40");

                entity.Property(e => e.OP50)
                    .IsUnicode(false)
                    .HasColumnName("OP50");

                entity.Property(e => e.OP60)
                    .IsUnicode(false)
                    .HasColumnName("OP60");

                entity.Property(e => e.OP65)
                    .IsUnicode(false)
                    .HasColumnName("OP65");

                entity.Property(e => e.OP70)
                    .IsUnicode(false)
                    .HasColumnName("OP10");

                entity.Property(e => e.OP75)
                    .IsUnicode(false)
                    .HasColumnName("OP75");

                entity.Property(e => e.OP80)
                    .IsUnicode(false)
                    .HasColumnName("OP80");

                entity.Property(e => e.OP85)
                    .IsUnicode(false)
                    .HasColumnName("OP85");

                entity.Property(e => e.OP90)
                    .IsUnicode(false)
                   .HasColumnName("OP90");

                entity.Property(e => e.OP100)
                    .IsUnicode(false)
                    .HasColumnName("OP100");

                entity.Property(e => e.OP110)
                    .IsUnicode(false)
                    .HasColumnName("OP110");

                entity.Property(e => e.OP115)
                    .IsUnicode(false)
                    .HasColumnName("OP115");

                entity.Property(e => e.OP120)
                    .IsUnicode(false)
                    .HasColumnName("OP120");

                entity.Property(e => e.OP130)
                    .IsUnicode(false)
                    .HasColumnName("OP130");

                entity.Property(e => e.OP135)
                    .IsUnicode(false)
                    .HasColumnName("OP135");

                entity.Property(e => e.OP140)
                    .IsUnicode(false)
                    .HasColumnName("OP140");

                entity.Property(e => e.OP150)
                    .IsUnicode(false)
                    .HasColumnName("OP150");

                entity.Property(e => e.OP160)
                    .IsUnicode(false)
                    .HasColumnName("OP160");

                entity.Property(e => e.OP170)
                    .IsUnicode(false)
                    .HasColumnName("OP170");

                entity.Property(e => e.OP180_1)
                    .IsUnicode(false)
                    .HasColumnName("OP180-1");

                entity.Property(e => e.OP185)
                    .IsUnicode(false)
                    .HasColumnName("OP185");

                entity.Property(e => e.OP190)
                    .IsUnicode(false)
                    .HasColumnName("OP190");

                entity.Property(e => e.OP200)
                    .IsUnicode(false)
                    .HasColumnName("OP200");

                entity.Property(e => e.OP210)
                    .IsUnicode(false)
                    .HasColumnName("OP210");

                entity.Property(e => e.OP215)
                    .IsUnicode(false)
                    .HasColumnName("OP215");

                entity.Property(e => e.OP220)
                    .IsUnicode(false)
                    .HasColumnName("OP220");

                entity.Property(e => e.OP230)
                    .IsUnicode(false)
                    .HasColumnName("OP230");

                entity.Property(e => e.OP240)
                    .IsUnicode(false)
                    .HasColumnName("OP240");

            });

            modelBuilder.Entity<GetBatteryDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_BinDetails");

                entity.Property(e => e.LineName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LineName");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.StationId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("StationId");

                entity.Property(e => e.ParameterId)
                    .IsUnicode(false)
                    .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterVal)
                    .IsUnicode(false)
                    .HasColumnName("ParameterVal");

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.Property(e => e.Category)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.SubCategory)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory");

                entity.Property(e => e.OperatorRemark)
                    .IsUnicode(false)
                    .HasColumnName("OperatorRemark");

                entity.Property(e => e.BUGId)
                    .IsUnicode(false)
                    .HasColumnName("BUGId");

                entity.Property(e => e.QIRemarks)
                    .IsUnicode(false)
                    .HasColumnName("QIRemarks");

                entity.Property(e => e.RSARemark)
                    .IsUnicode(false)
                    .HasColumnName("RSARemark");

                entity.Property(e => e.ReEntryStation)
                    .IsUnicode(false)
                    .HasColumnName("ReEntryStation");

                entity.Property(e => e.StartTime)
                    .IsUnicode(false)
                    .HasColumnName("StartTime");

                entity.Property(e => e.EndTime)
                    .IsUnicode(false)
                    .HasColumnName("EndTime");

                entity.Property(e => e.SaveFlag)
                    .IsUnicode(false)
                    .HasColumnName("SaveFlag");

                entity.Property(e => e.ReworkRemark)
                    .IsUnicode(false)
                    .HasColumnName("ReworkRemark");

                entity.Property(e => e.PartChangeFlag)
                    .IsUnicode(false)
                    .HasColumnName("PartChangeFlag");

                entity.Property(e => e.SKUChangeFlag)
                    .IsUnicode(false)
                    .HasColumnName("SKUChangeFlag");




            });

            modelBuilder.Entity<GetBatteryDetailsCommon>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_BinDetailsCommon");

                entity.Property(e => e.LineId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LineId");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.StationId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("StationId");

                entity.Property(e => e.ParameterId)
                    .IsUnicode(false)
                    .HasColumnName("ParameterId");

                entity.Property(e => e.ParameterVal)
                    .IsUnicode(false)
                    .HasColumnName("ParameterVal");

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.Property(e => e.Category)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.SubCategory)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory");

                entity.Property(e => e.OperatorRemark)
                    .IsUnicode(false)
                    .HasColumnName("OperatorRemark");

                entity.Property(e => e.BUGId)
                    .IsUnicode(false)
                    .HasColumnName("BUGId");

                entity.Property(e => e.QIRemarks)
                    .IsUnicode(false)
                    .HasColumnName("QIRemarks");

                entity.Property(e => e.RSARemark)
                    .IsUnicode(false)
                    .HasColumnName("RSARemark");

                //entity.Property(e => e.ReEntryStation)
                //    .IsUnicode(false)
                //    .HasColumnName("ReEntryStation");

                //entity.Property(e => e.StartTime)
                //    .IsUnicode(false)
                //    .HasColumnName("StartTime");

                //entity.Property(e => e.EndTime)
                //    .IsUnicode(false)
                //    .HasColumnName("EndTime");

                entity.Property(e => e.SaveFlag)
                    .IsUnicode(false)
                    .HasColumnName("SaveFlag");

                entity.Property(e => e.ReworkRemark)
                    .IsUnicode(false)
                    .HasColumnName("ReworkRemark");

                entity.Property(e => e.PartChangeFlag)
                    .IsUnicode(false)
                    .HasColumnName("PartChangeFlag");

                entity.Property(e => e.SKUChangeFlag)
                    .IsUnicode(false)
                    .HasColumnName("SKUChangeFlag");




            });
            modelBuilder.Entity<CheckList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_CheckList");

                entity.Property(e => e.CheckListId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckListId");

                entity.Property(e => e.StartDateTime)
                    .IsUnicode(false)
                    .HasColumnName("StartDateTime");

                entity.Property(e => e.FrequencyType)
                    .IsUnicode(false)
                    .HasColumnName("FrequencyType");

                entity.Property(e => e.FrequencyValue)
                    .IsUnicode(false)
                    .HasColumnName("FrequencyValue");

                entity.Property(e => e.FrequencyDuration)
                    .IsUnicode(false)
                    .HasColumnName("FrequencyDuration");

                entity.Property(e => e.Alert)
                    .IsUnicode(false)
                    .HasColumnName("Alert");

                entity.Property(e => e.EstimatedDuration)
                    .IsUnicode(false)
                    .HasColumnName("EstimatedDuration");

                entity.Property(e => e.CompletonDateTime)
                    .IsUnicode(false)
                    .HasColumnName("CompletonDateTime");

                entity.Property(e => e.DueDateTime)
                    .IsUnicode(false)
                    .HasColumnName("DueDateTime");

                entity.Property(e => e.AssignedUser)
                    .IsUnicode(false)
                    .HasColumnName("AssignedUser");

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.Property(e => e.Part_Number_with_rev)
                    .IsUnicode(false)
                    .HasColumnName("Part Number with rev.:");

                entity.Property(e => e.Part_Name_Description)
                    .IsUnicode(false)
                    .HasColumnName("Part Name/Description");

                entity.Property(e => e.Module_Line_No)
                    .IsUnicode(false)
                    .HasColumnName("Module / Line No.");

                entity.Property(e => e.Part_Criticality)
                    .IsUnicode(false)
                    .HasColumnName("Part Criticality");

                entity.Property(e => e.IPIS_No)
                    .IsUnicode(false)
                    .HasColumnName("IPIS No.");

                entity.Property(e => e.CPRef)
                    .IsUnicode(false)
                    .HasColumnName("CPRef");

                entity.Property(e => e.Customer)
                    .IsUnicode(false)
                    .HasColumnName("Customer");

                entity.Property(e => e.Model)
                    .IsUnicode(false)
                    .HasColumnName("Model");

                entity.Property(e => e.LineId)
                    .IsUnicode(false)
                    .HasColumnName("LineId");

                entity.Property(e => e.CheckListName)
                    .IsUnicode(false)
                    .HasColumnName("CheckListName");

                entity.Property(e => e.CheckListDescription)
                    .IsUnicode(false)
                    .HasColumnName("CheckListDescription");

                entity.Property(e => e.SOPFilePath)
                    .IsUnicode(false)
                    .HasColumnName("SOPFilePath");

                entity.Property(e => e.CheckListType)
                    .IsUnicode(false)
                    .HasColumnName("CheckListType");

                entity.Property(e => e.Phase)
                    .IsUnicode(false)
                    .HasColumnName("Phase");

            });

            modelBuilder.Entity<CheckPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Config_IPQCCheckPoint");

                entity.Property(e => e.CheckPointId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointId");

                entity.Property(e => e.CheckPointName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointName");

                entity.Property(e => e.CheckPointDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointDescription");

                entity.Property(e => e.CheckListID)
                    .IsUnicode(false)
                    .HasColumnName("CheckListID");

                entity.Property(e => e.Category)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.StationID)
                    .IsUnicode(false)
                    .HasColumnName("StationID");

                entity.Property(e => e.EstimatedDuration)
                    .IsUnicode(false)
                    .HasColumnName("EstimatedDuration");

                entity.Property(e => e.LowerLimit)
                    .IsUnicode(false)
                    .HasColumnName("LowerLimit");

                entity.Property(e => e.UpperLimit)
                    .IsUnicode(false)
                    .HasColumnName("UpperLimit");

                entity.Property(e => e.UoM)
                    .IsUnicode(false)
                    .HasColumnName("UoM");

                entity.Property(e => e.CheckPointType)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointType");

                entity.Property(e => e.Criticality)
                    .IsUnicode(false)
                    .HasColumnName("Criticality");

                entity.Property(e => e.CreatedOn)
                    .IsUnicode(false)
                    .HasColumnName("CreatedOn");

                entity.Property(e => e.CreatedBy)
                    .IsUnicode(false)
                    .HasColumnName("CreatedBy");

                entity.Property(e => e.LastUpdatedOn)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedOn");

                entity.Property(e => e.LastUpdateBy)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdateBy");
            });


            modelBuilder.Entity<CheckPoints>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v_Ipqc_checkpoint");         
      
                entity.Property(e => e.CheckPointId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointId");

                entity.Property(e => e.CheckPointName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointName");

                entity.Property(e => e.CheckPointDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointDescription");

                entity.Property(e => e.CheckListID)
                    .IsUnicode(false)
                    .HasColumnName("CheckListID");

                entity.Property(e => e.Category)
                    .IsUnicode(false)
                    .HasColumnName("Category");

                entity.Property(e => e.StationID)
                    .IsUnicode(false)
                    .HasColumnName("StationID");

                entity.Property(e => e.EstimatedDuration)
                    .IsUnicode(false)
                    .HasColumnName("EstimatedDuration");

                entity.Property(e => e.LowerLimit)
                    .IsUnicode(false)
                    .HasColumnName("LowerLimit");

                entity.Property(e => e.UpperLimit)
                    .IsUnicode(false)
                    .HasColumnName("UpperLimit");

                entity.Property(e => e.UoM)
                    .IsUnicode(false)
                    .HasColumnName("UoM");

                entity.Property(e => e.CheckPointType)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointType");

                entity.Property(e => e.Criticality)
                    .IsUnicode(false)
                    .HasColumnName("Criticality");

                entity.Property(e => e.CreatedOn)
                    .IsUnicode(false)
                    .HasColumnName("CreatedOn");

                entity.Property(e => e.CreatedBy)
                    .IsUnicode(false)
                    .HasColumnName("CreatedBy");

                entity.Property(e => e.LastUpdatedOn)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdatedOn");

                entity.Property(e => e.LastUpdateBy)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdateBy");


                entity.Property(e => e.CheckPointValue)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointValue");


                entity.Property(e => e.CheckPointStatus)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointStatus");

                entity.Property(e => e.Remark)
                    .IsUnicode(false)
                    .HasColumnName("Remark");

                entity.Property(e => e.Instance)
                    .IsUnicode(false)
                    .HasColumnName("Instance");

                


            });


            modelBuilder.Entity<StatusGenealogy>(entity =>
            {
               
                entity.HasKey(e => e.Rowid);
                
                entity.ToTable("Prod_StatusGeneology");

                entity.Property(e => e.Proddate)
                   .IsUnicode(false)
                   .HasColumnName("ProdDate");


                entity.Property(e => e.ProdShift)
                    .IsUnicode(false)
                    .HasColumnName("ProdShift");

                entity.Property(e => e.Timestamp)
                   .IsUnicode(false)
                   .HasColumnName("Timestamp");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.SKU)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.StationId)
                    .IsUnicode(false)
                    .HasColumnName("StationId");

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .HasColumnName("Status");                            
             });

            modelBuilder.Entity<PMCheckPoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Config_PMCheckPoint");

                entity.Property(e => e.CheckListID)
                    .IsUnicode(false)
                    .HasColumnName("CheckListID");

            });

            modelBuilder.Entity<BatteryWIP>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("Prod_BatteryWIPLine");

                entity.Property(e => e.RowId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowId");

                entity.Property(e => e.BIN_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIN_Number");

                entity.Property(e => e.LineName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LineName");

                entity.Property(e => e.StartTime)
                    .IsUnicode(false)
                    .HasColumnName("StartTime");

                entity.Property(e => e.EndTime)
                    .IsUnicode(false)
                    .HasColumnName("EndTime");

                entity.Property(e => e.ReEntryStation)
                    .IsUnicode(false)
                    .HasColumnName("ReEntryStation");

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .HasColumnName("Status");

                entity.Property(e => e.SaveFlag)
                    .IsUnicode(false)
                    .HasColumnName("SaveFlag");

                entity.Property(e => e.PlanID)
                    .IsUnicode(false)
                    .HasColumnName("PlanID");


            });

            modelBuilder.Entity<IPQCSaveClose>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("Quality_Execute_IPQCChecklist");

                entity.Property(e => e.RowId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowId");

                entity.Property(e => e.CheckListId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckListId");

                entity.Property(e => e.CheckPointId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointId");

                entity.Property(e => e.CheckPointStatus)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointStatus");

                entity.Property(e => e.CheckPointValue)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointValue");

                entity.Property(e => e.Remark)
                    .IsUnicode(false)
                    .HasColumnName("Remark");

            });

            modelBuilder.Entity<PMSaveClose>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("Maint_Execute_PMChecklist");

                entity.Property(e => e.RowId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowId");

                entity.Property(e => e.CheckListId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckListId");

                entity.Property(e => e.CheckPointId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointId");

                entity.Property(e => e.CheckPointStatus)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointStatus");

                entity.Property(e => e.CheckPointValue)
                    .IsUnicode(false)
                    .HasColumnName("CheckPointValue");

                entity.Property(e => e.Remark)
                    .IsUnicode(false)
                    .HasColumnName("Remark");

            });

            modelBuilder.Entity<PMCheckList>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToView("v_PMCheckList");

                entity.Property(e => e.RowId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowId");

                entity.Property(e => e.Phase)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Phase");
            });

            modelBuilder.Entity<JHCheckList>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToView("v_JHCheckList");

                entity.Property(e => e.RowId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RowId");
            });

            modelBuilder.Entity<v_Maint_Breakdown_Log>(entity =>
            {
                entity.HasKey(e => e.BreakdownID);

                entity.ToView("v_Maint_Breakdown_Log");

                entity.Property(e => e.BreakdownID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BreakdownID");

            });

            modelBuilder.Entity<v_Config_User_Common>(entity =>
            {
                entity.HasKey(e => e.UserID);

                entity.ToView("v_Config_User_Common");

                entity.Property(e => e.UserID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

            });

            modelBuilder.Entity<v_SAP_B_PROD_ORDER>(entity =>
            {
                entity.HasKey(e => e.UID);

                entity.ToView("v_SAP_B_PROD_ORDER");

                entity.Property(e => e.UID)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UID");

            });

            modelBuilder.Entity<Config_User>(entity =>

            {
                entity.HasNoKey();


                entity.ToView("Config_User");

                entity.Property(e => e.UserId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UserId");

                entity.Property(e => e.Username)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Username");

                entity.Property(e => e.UserPWD)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UserPWD");

                entity.Property(e => e.UserEMail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UserEMail");

                entity.Property(e => e.UserMobile)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("UserMobile");

                entity.Property(e => e.Token)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Token");

            });


            //modelBuilder.Entity<Quality_DHCImage>(entity =>
            //{
            //    entity.HasKey(e => e.RowID)
            //    .HasName("RowID");

            //    entity.ToTable("Quality_DHCImage");

            //    entity.Property(e => e.RowID)
            //        .HasMaxLength(50)
            //        .IsUnicode(false)
            //        .HasColumnName("RowID");

            //});



            //modelBuilder.Entity<JIRA_Send_Data>(entity =>
            //{
            //    entity.HasKey(e => e.Timestamp);

            //    entity.ToTable("JIRA_Send_Data");

            //    entity.Property(e => e.Timestamp)
            //        .IsUnicode(false)
            //        .HasColumnName("Timestamp");

            //    entity.Property(e => e.BIN_Number)
            //        .IsUnicode(false)
            //        .HasColumnName("BIN_Number");

            //    entity.Property(e => e.LineName)
            //        .IsUnicode(false)
            //        .HasColumnName("LineName");

            //    entity.Property(e => e.StationName)
            //        .IsUnicode(false)
            //        .HasColumnName("StationName");

            //    entity.Property(e => e.Parameter_Name)
            //        .IsUnicode(false)
            //        .HasColumnName("Parameterid");

            //    entity.Property(e => e.CategoryName)
            //        .IsUnicode(false)
            //        .HasColumnName("CategoryName");

            //    entity.Property(e => e.SubCategoryName)
            //        .IsUnicode(false)
            //        .HasColumnName("SubCategoryName");

            //    entity.Property(e => e.OperatorRemark)
            //        .IsUnicode(false)
            //        .HasColumnName("OperatorRemark");

            //    entity.Property(e => e.Bugid)
            //        .IsUnicode(false)
            //        .HasColumnName("Bugid");

            //    entity.Property(e => e.QIRemark)
            //        .IsUnicode(false)
            //        .HasColumnName("QIRemark");

            //    entity.Property(e => e.Status)
            //         .HasMaxLength(100)
            //        .IsUnicode(false)
            //        .HasColumnName("Status");



            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
