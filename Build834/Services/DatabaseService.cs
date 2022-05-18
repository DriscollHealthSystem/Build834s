using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Build834.Models;
using NLog;

namespace Build834.Services
{
    static public class DatabaseService
    {
        private static string ConnectionString;

        public static List<Member_STAR_SK> GetMembers_STAR_SK(String PlanCode)
        {
            List<Member_STAR_SK> members = new List<Member_STAR_SK>();

            switch (PlanCode)
            {
                case "H4":
                    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_H4"].ConnectionString;
                    break;
                case "82":
                    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_82"].ConnectionString;
                    break;
                case "KC":
                    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_KC"].ConnectionString;
                    break;
                case "KD":
                    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_KD"].ConnectionString;
                    break;
            }

            String query = "SELECT [ReasonType],[ReasonCode],[BenefitStatus],[MedicareStatus],[SpecialNeeds],[SSN],[SSN_LineId],[PolicyNumber],[RiskGroup],[MedicaidId]," +
                "[MedicaidCertification],[MedicaidBegin_1],[MedicaidEnd_1],[MedicaidBegin_2],[Member_LastName],[Member_FirstName],[Member_MiddleName],[Member_Prefix],[Member_Suffix]," +
                "[Member_Comm_Qualifier_1],[Member_Comm_Number_1],[Member_Comm_Qualifier_2],[Member_Comm_Number_2],[Member_Comm_Qualifier_3],[Member_Comm_Number_3]," +
                "[Member_Address_1],[Member_Address_2],[Member_City],[Member_State],[Member_PostalCode],[Member_CountryCode],[Member_CountyCode],[Member_Demographics_BirthDate]," +
                "[Member_Demographics_GenderCode],[Member_Demographics_MaritalStatusCode],[Member_Demographics_RaceEthnicityCode],[Member_Language_IdentificationCode]," +
                "[Member_Language_UseIndicator],[Member_MailingAddress_1],[Member_MailingAddress_2],[Member_MailingCity],[Member_MailingState],[Member_MailingPostalCode]," +
                "[Member_MailingCountryCode],[Member_CustodialParent_LastName],[Member_CustodialParent_FirstName],[Member_CustodialParent_MiddleName]," +
                "[Member_ResponsiblePerson_LastName],[Member_ResponsiblePerson_FirstName],[Member_ResponsiblePerson_MiddleName],[Member_ResponsiblePerson_Prefix]," +
                "[Member_ResponsiblePerson_Suffix],[Member_ResponsiblePerson_MedicaidNumber],[Member_ResponsiblePersonComm_Qualifier_1],[Member_ResponsiblePersonComm_Number_1]," +
                "[Member_ResponsiblePersonComm_Qualifier_2],[Member_ResponsiblePersonComm_Number_2],[Member_ResponsiblePersonComm_Qualifier_3]," +
                "[Member_ResponsiblePersonComm_Number_3],[Employer_Group],[Provider_EntityIdentifier],[Provider_EntityType],[Provider_IdentificationCodeQual],[Provider_NPI]," +
                "[Provider_RelationShip_Code],[Provider_Address],[Provider_City],[Provider_State],[Provider_PostalCode],[Provider_ActionCode],[Provider_EntityIdentifierCode]," +
                "[Provider_EffectiveDate],[Provider_MaintenanceReasonCode],[EPIC_Location_ID],[MedicareId],[MedicareEpicId],[MedicareBegin],[MedicareEnd],[PreviousId]," +
                "[PreviousEpicId],[CaseId],[CaseEpicId],[MedicareDualIndicator],[MedicareDualIndicatorEpicId],[MothersMedicaidIdNumber],[MothersMedicaidIdNumberEpicId]," +
                "[MedicaidRecertification],[MedicaidRecertificationEpicId],[ApplicationReceived],[ApplicationReceivedEpicId],[HC_CoveragePeriodBegin_Current]," +
                "[HC_CoveragePeriodEnd_Current],[HC_CoveragePeriodBegin_Future],[HC_HMO_Migrant_Current],[HC_HMO_Migrant_Current_EpicId],[HC_HMO_Migrant_Future]," +
                "[HC_HMO_Migrant_Future_EpicId],[HC_FAC_DentalPlan_Current],[HC_FAC_DentalPlan_Current_EpicId],[HC_FAC_DentalPlan_Future],[HC_FAC_DentalPlan_Future_EpicId]," +
                "[HC_HMO_PrenatalPCP_Current],[HC_HMO_PrenatalPCP_Current_EpicId],[HC_HMO_PrenatalPCP_Future],[HC_HMO_PrenatalPCP_Future_EpicId]," +
                "[HC_HMO_MedicaidTypeProgram_Current],[HC_HMO_MedicaidTypeProgram_Current_EpicId],[HC_HMO_MedicaidTypeProgram_Future],[HC_HMO_MedicaidTypeProgram_Future_EpicId]," +
                "[HC_HMO_MedicaidCategory_Current],[HC_HMO_MedicaidCategory_Current_EpicId],[HC_HMO_MedicaidCategory_Future],[HC_HMO_MedicaidCategory_Future_EpicId]," +
                "[HC_HMO_MedicaidCoverageCode_Current],[HC_HMO_MedicaidCoverageCode_Current_EpicId],[HC_HMO_MedicaidCoverageCode_Future]," +
                "[HC_HMO_MedicaidCoverageCode_Future_EpicId],[HC_HLT_WaiverTOA_Current],[HC_HLT_WaiverTOA_Current_EpicId],[HC_HLT_WaiverTOA_Future]," +
                "[HC_HLT_WaiverTOA_Future_EpicId],[HC_HLT_TiersTOA_Current],[HC_HLT_TiersTOA_Current_EpicId],[HC_HLT_TiersTOA_Future],[HC_HLT_TiersTOA_Future_EpicId]," +
                "[HC_FAC_PlanCode_Current],[HC_FAC_PlanCode_Current_EpicId],[HC_FAC_PlanCode_Future],[HC_FAC_PlanCode_Future_EpicId],[HC_POS_First_Pregnancy_Current]," +
                "[HC_POS_First_Pregnancy_Current_EpicId],[HC_POS_PreferredLanguage_Current],[HC_POS_PreferredLanguage_Current_EpicId],[HC_POS_ContactPreference_1_Current]," +
                "[HC_POS_ContactPreference_1_Current_EpicId],[HC_POS_ContactPreference_2_Current],[HC_POS_ContactPreference_2_Current_EpicId]," +
                "[HC_POS_ContactPreference_3_Current],[HC_POS_ContactPreference_3_Current_EpicId],[RiskGroup_Current]," +
                "[RiskGroup_Current_EpicId],[RiskGroup_Future],[RiskGroup_Future_EpicId] FROM [TxMedCentral_" + PlanCode + "].[834].[Staging_834]";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Member_STAR_SK member = new Member_STAR_SK();
                    member.ReasonType = rdr["ReasonType"] as string;
                    member.ReasonCode = rdr["ReasonCode"] as string;
                    member.BenefitStatus = rdr["BenefitStatus"] as string;
                    member.MedicareStatus = rdr["MedicareStatus"] as string;
                    member.SpecialNeeds = rdr["SpecialNeeds"] as string;
                    member.SSN = rdr["SSN"] as string;
                    member.SSN_LineId = rdr["SSN_LineId"] as string;
                    member.PolicyNumber = rdr["PolicyNumber"] as string;
                    member.RiskGroup = rdr["RiskGroup"] as string;
                    member.MedicaidId = rdr["MedicaidId"] as string;
                    member.MedicaidCertification = rdr["MedicaidCertification"] as string;
                    member.MedicaidBegin_1 = rdr["MedicaidBegin_1"] as string;
                    member.MedicaidEnd_1 = rdr["MedicaidEnd_1"] as string;
                    member.MedicaidBegin_2 = rdr["MedicaidBegin_2"] as string;
                    member.Member_LastName = rdr["Member_LastName"] as string;
                    member.Member_FirstName = rdr["Member_FirstName"] as string;
                    member.Member_MiddleName = rdr["Member_MiddleName"] as string;
                    member.Member_Prefix = rdr["Member_Prefix"] as string;
                    member.Member_Suffix = rdr["Member_Suffix"] as string;
                    member.Member_Comm_Qualifier_1 = rdr["Member_Comm_Qualifier_1"] as string;
                    member.Member_Comm_Number_1 = rdr["Member_Comm_Number_1"] as string;
                    member.Member_Comm_Qualifier_2 = rdr["Member_Comm_Qualifier_2"] as string;
                    member.Member_Comm_Number_2 = rdr["Member_Comm_Number_2"] as string;
                    member.Member_Comm_Qualifier_3 = rdr["Member_Comm_Qualifier_3"] as string;
                    member.Member_Comm_Number_3 = rdr["Member_Comm_Number_3"] as string;
                    member.Member_Address_1 = rdr["Member_Address_1"] as string;
                    member.Member_Address_2 = rdr["Member_Address_2"] as string;
                    member.Member_City = rdr["Member_City"] as string;
                    member.Member_State = rdr["Member_State"] as string;
                    member.Member_PostalCode = rdr["Member_PostalCode"] as string;
                    member.Member_CountryCode = rdr["Member_CountryCode"] as string;
                    member.Member_CountyCode = rdr["Member_CountyCode"] as string;
                    member.Member_Demographics_BirthDate = rdr["Member_Demographics_BirthDate"] as string;
                    member.Member_Demographics_GenderCode = rdr["Member_Demographics_GenderCode"] as string;
                    member.Member_Demographics_MaritalStatusCode = rdr["Member_Demographics_MaritalStatusCode"] as string;
                    member.Member_Demographics_RaceEthnicityCode = rdr["Member_Demographics_RaceEthnicityCode"] as string;
                    member.Member_Language_IdentificationCode = rdr["Member_Language_IdentificationCode"] as string;
                    member.Member_Language_UseIndicator = rdr["Member_Language_UseIndicator"] as string;
                    member.Member_MailingAddress_1 = rdr["Member_MailingAddress_1"] as string;
                    member.Member_MailingAddress_2 = rdr["Member_MailingAddress_2"] as string;
                    member.Member_MailingCity = rdr["Member_MailingCity"] as string;
                    member.Member_MailingState = rdr["Member_MailingState"] as string;
                    member.Member_MailingPostalCode = rdr["Member_MailingPostalCode"] as string;
                    member.Member_MailingCountryCode = rdr["Member_MailingCountryCode"] as string;
                    member.Member_CustodialParent_LastName = rdr["Member_CustodialParent_LastName"] as string;
                    member.Member_CustodialParent_FirstName = rdr["Member_CustodialParent_FirstName"] as string;
                    member.Member_CustodialParent_MiddleName = rdr["Member_CustodialParent_MiddleName"] as string;
                    member.Member_ResponsiblePerson_LastName = rdr["Member_ResponsiblePerson_LastName"] as string;
                    member.Member_ResponsiblePerson_FirstName = rdr["Member_ResponsiblePerson_FirstName"] as string;
                    member.Member_ResponsiblePerson_MiddleName = rdr["Member_ResponsiblePerson_MiddleName"] as string;
                    member.Member_ResponsiblePerson_Prefix = rdr["Member_ResponsiblePerson_Prefix"] as string;
                    member.Member_ResponsiblePerson_Suffix = rdr["Member_ResponsiblePerson_Suffix"] as string;
                    member.Member_ResponsiblePerson_MedicaidNumber = rdr["Member_ResponsiblePerson_MedicaidNumber"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_1 = rdr["Member_ResponsiblePersonComm_Qualifier_1"] as string;
                    member.Member_ResponsiblePersonComm_Number_1 = rdr["Member_ResponsiblePersonComm_Number_1"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_2 = rdr["Member_ResponsiblePersonComm_Qualifier_2"] as string;
                    member.Member_ResponsiblePersonComm_Number_2 = rdr["Member_ResponsiblePersonComm_Number_2"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_3 = rdr["Member_ResponsiblePersonComm_Qualifier_3"] as string;
                    member.Member_ResponsiblePersonComm_Number_3 = rdr["Member_ResponsiblePersonComm_Number_3"] as string;
                    member.Employer_Group = rdr["Employer_Group"] as string;
                    member.Provider_EntityIdentifier = rdr["Provider_EntityIdentifier"] as string;
                    member.Provider_EntityType = rdr["Provider_EntityType"] as string;
                    member.Provider_IdentificationCodeQual = rdr["Provider_IdentificationCodeQual"] as string;
                    member.Provider_NPI = rdr["Provider_NPI"] as string;
                    member.Provider_RelationShip_Code = rdr["Provider_RelationShip_Code"] as string;
                    member.Provider_Address = rdr["Provider_Address"] as string;
                    member.Provider_City = rdr["Provider_City"] as string;
                    member.Provider_State = rdr["Provider_State"] as string;
                    member.Provider_PostalCode = rdr["Provider_PostalCode"] as string;
                    member.Provider_ActionCode = rdr["Provider_ActionCode"] as string;
                    member.Provider_EntityIdentifierCode = rdr["Provider_EntityIdentifierCode"] as string;
                    member.Provider_EffectiveDate = rdr["Provider_EffectiveDate"] as string;
                    member.Provider_MaintenanceReasonCode = rdr["Provider_MaintenanceReasonCode"] as string;
                    member.EPIC_Location_ID = rdr["EPIC_Location_ID"] as string;
                    member.MedicareId = rdr["MedicareId"] as string;
                    member.MedicareEpicId = rdr["MedicareEpicId"] as string;
                    member.MedicareBegin = rdr["MedicareBegin"] as string;
                    member.MedicareEnd = rdr["MedicareEnd"] as string;
                    member.PreviousId = rdr["PreviousId"] as string;
                    member.PreviousEpicId = rdr["PreviousEpicId"] as string;
                    member.CaseId = rdr["CaseId"] as string;
                    member.CaseEpicId = rdr["CaseEpicId"] as string;
                    member.MedicareDualIndicator = rdr["MedicareDualIndicator"] as string;
                    member.MedicareDualIndicatorEpicId = rdr["MedicareDualIndicatorEpicId"] as string;
                    member.MothersMedicaidIdNumber = rdr["MothersMedicaidIdNumber"] as string;
                    member.MothersMedicaidIdNumberEpicId = rdr["MothersMedicaidIdNumberEpicId"] as string;
                    member.MedicaidRecertification = rdr["MedicaidRecertification"] as string;
                    member.MedicaidRecertificationEpicId = rdr["MedicaidRecertificationEpicId"] as string;
                    member.ApplicationReceived = rdr["ApplicationReceived"] as string;
                    member.ApplicationReceivedEpicId = rdr["ApplicationReceivedEpicId"] as string;
                    member.HC_CoveragePeriodBegin_Current = rdr["HC_CoveragePeriodBegin_Current"] as string;
                    member.HC_CoveragePeriodEnd_Current = rdr["HC_CoveragePeriodEnd_Current"] as string;
                    member.HC_CoveragePeriodBegin_Future = rdr["HC_CoveragePeriodBegin_Future"] as string;
                    member.HC_HMO_Migrant_Current = rdr["HC_HMO_Migrant_Current"] as string;
                    member.HC_HMO_Migrant_Current_EpicId = rdr["HC_HMO_Migrant_Current_EpicId"] as string;
                    member.HC_HMO_Migrant_Future = rdr["HC_HMO_Migrant_Future"] as string;
                    member.HC_HMO_Migrant_Future_EpicId = rdr["HC_HMO_Migrant_Future_EpicId"] as string;
                    member.HC_FAC_DentalPlan_Current = rdr["HC_FAC_DentalPlan_Current"] as string;
                    member.HC_FAC_DentalPlan_Current_EpicId = rdr["HC_FAC_DentalPlan_Current_EpicId"] as string;
                    member.HC_FAC_DentalPlan_Future = rdr["HC_FAC_DentalPlan_Future"] as string;
                    member.HC_FAC_DentalPlan_Future_EpicId = rdr["HC_FAC_DentalPlan_Future_EpicId"] as string;
                    member.HC_HMO_PrenatalPCP_Current = rdr["HC_HMO_PrenatalPCP_Current"] as string;
                    member.HC_HMO_PrenatalPCP_Current_EpicId = rdr["HC_HMO_PrenatalPCP_Current_EpicId"] as string;
                    member.HC_HMO_PrenatalPCP_Future = rdr["HC_HMO_PrenatalPCP_Future"] as string;
                    member.HC_HMO_PrenatalPCP_Future_EpicId = rdr["HC_HMO_PrenatalPCP_Future_EpicId"] as string;
                    member.HC_HMO_MedicaidTypeProgram_Current = rdr["HC_HMO_MedicaidTypeProgram_Current"] as string;
                    member.HC_HMO_MedicaidTypeProgram_Current_EpicId = rdr["HC_HMO_MedicaidTypeProgram_Current_EpicId"] as string;
                    member.HC_HMO_MedicaidTypeProgram_Future = rdr["HC_HMO_MedicaidTypeProgram_Future"] as string;
                    member.HC_HMO_MedicaidTypeProgram_Future_EpicId = rdr["HC_HMO_MedicaidTypeProgram_Future_EpicId"] as string;
                    member.HC_HMO_MedicaidCategory_Current = rdr["HC_HMO_MedicaidCategory_Current"] as string;
                    member.HC_HMO_MedicaidCategory_Current_EpicId = rdr["HC_HMO_MedicaidCategory_Current_EpicId"] as string;
                    member.HC_HMO_MedicaidCategory_Future = rdr["HC_HMO_MedicaidCategory_Future"] as string;
                    member.HC_HMO_MedicaidCategory_Future_EpicId = rdr["HC_HMO_MedicaidCategory_Future_EpicId"] as string;
                    member.HC_HMO_MedicaidCoverageCode_Current = rdr["HC_HMO_MedicaidCoverageCode_Current"] as string;
                    member.HC_HMO_MedicaidCoverageCode_Current_EpicId = rdr["HC_HMO_MedicaidCoverageCode_Current_EpicId"] as string;
                    member.HC_HMO_MedicaidCoverageCode_Future = rdr["HC_HMO_MedicaidCoverageCode_Future"] as string;
                    member.HC_HMO_MedicaidCoverageCode_Future_EpicId = rdr["HC_HMO_MedicaidCoverageCode_Future_EpicId"] as string;
                    member.HC_HLT_WaiverTOA_Current = rdr["HC_HLT_WaiverTOA_Current"] as string;
                    member.HC_HLT_WaiverTOA_Current_EpicId = rdr["HC_HLT_WaiverTOA_Current_EpicId"] as string;
                    member.HC_HLT_WaiverTOA_Future = rdr["HC_HLT_WaiverTOA_Future"] as string;
                    member.HC_HLT_WaiverTOA_Future_EpicId = rdr["HC_HLT_WaiverTOA_Future_EpicId"] as string;
                    member.HC_HLT_TiersTOA_Current = rdr["HC_HLT_TiersTOA_Current"] as string;
                    member.HC_HLT_TiersTOA_Current_EpicId = rdr["HC_HLT_TiersTOA_Current_EpicId"] as string;
                    member.HC_HLT_TiersTOA_Future = rdr["HC_HLT_TiersTOA_Future"] as string;
                    member.HC_HLT_TiersTOA_Future_EpicId = rdr["HC_HLT_TiersTOA_Future_EpicId"] as string;
                    member.HC_FAC_PlanCode_Current = rdr["HC_FAC_PlanCode_Current"] as string;
                    member.HC_FAC_PlanCode_Current_EpicId = rdr["HC_FAC_PlanCode_Current_EpicId"] as string;
                    member.HC_FAC_PlanCode_Future = rdr["HC_FAC_PlanCode_Future"] as string;
                    member.HC_FAC_PlanCode_Future_EpicId = rdr["HC_FAC_PlanCode_Future_EpicId"] as string;
                    member.HC_POS_First_Pregnancy_Current = rdr["HC_POS_First_Pregnancy_Current"] as string;
                    member.HC_POS_First_Pregnancy_Current_EpicId = rdr["HC_POS_First_Pregnancy_Current_EpicId"] as string;
                    member.HC_POS_PreferredLanguage_Current = rdr["HC_POS_PreferredLanguage_Current"] as string;
                    member.HC_POS_PreferredLanguage_Current_EpicId = rdr["HC_POS_PreferredLanguage_Current_EpicId"] as string;
                    member.HC_POS_ContactPreference_1_Current = rdr["HC_POS_ContactPreference_1_Current"] as string;
                    member.HC_POS_ContactPreference_1_Current_EpicId = rdr["HC_POS_ContactPreference_1_Current_EpicId"] as string;
                    member.HC_POS_ContactPreference_2_Current = rdr["HC_POS_ContactPreference_2_Current"] as string;
                    member.HC_POS_ContactPreference_2_Current_EpicId = rdr["HC_POS_ContactPreference_2_Current_EpicId"] as string;
                    member.HC_POS_ContactPreference_3_Current = rdr["HC_POS_ContactPreference_3_Current"] as string;
                    member.HC_POS_ContactPreference_3_Current_EpicId = rdr["HC_POS_ContactPreference_3_Current_EpicId"] as string;
                    member.RiskGroup_Current = rdr["RiskGroup_Current"] as string;
                    member.RiskGroup_Current_EpicId = rdr["RiskGroup_Current_EpicId"] as string;
                    member.RiskGroup_Future = rdr["RiskGroup_Future"] as string;
                    member.RiskGroup_Future_EpicId = rdr["RiskGroup_Future_EpicId"] as string;
                    members.Add(member);
                }
                return members;
            }
        }

        public static List<Member_STAR_SK_Daily> GetMembers_STAR_SK_Daily(String PlanCode)
        {
            List<Member_STAR_SK_Daily> members = new List<Member_STAR_SK_Daily>();

            switch (PlanCode)
            {
                case "H4":
                    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_H4"].ConnectionString;
                    break;
                case "82":
                    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_82"].ConnectionString;
                    break;
                case "KC":
                    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_KC"].ConnectionString;
                    break;
                case "KD":
                    ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_KD"].ConnectionString;
                    break;
            }

            String query = "SELECT [ReasonType],[ReasonCode],[BenefitStatus],[MedicareStatus],[SpecialNeeds],[SSN],[PolicyNumber],[RiskGroup],[MedicaidId],[MedicaidCertification]," +
                "[MedicaidBegin_1],[MedicaidEnd_1],[Member_LastName],[Member_FirstName],[Member_MiddleName],[Member_Prefix],[Member_Suffix],[Member_Comm_Qualifier_1],[Member_Comm_Number_1]," +
                "[Member_Comm_Qualifier_2],[Member_Comm_Number_2],[Member_Comm_Qualifier_3],[Member_Comm_Number_3],[Member_Address_1],[Member_Address_2],[Member_City],[Member_State]," +
                "[Member_PostalCode],[Member_CountryCode],[Member_CountyCode],[Member_Demographics_BirthDate],[Member_Demographics_GenderCode],[Member_Demographics_MaritalStatusCode]," +
                "[Member_Demographics_RaceEthnicityCode],[Member_Language_IdentificationCode],[Member_Language_UseIndicator],[Member_MailingAddress_1],[Member_MailingAddress_2]," +
                "[Member_MailingCity],[Member_MailingState],[Member_MailingPostalCode],[Member_MailingCountryCode],[Member_CustodialParent_LastName]," +
                "[Member_CustodialParent_FirstName],[Member_CustodialParent_MiddleName],[Member_ResponsiblePerson_LastName],[Member_ResponsiblePerson_FirstName]," +
                "[Member_ResponsiblePerson_MiddleName],[Member_ResponsiblePerson_Prefix],[Member_ResponsiblePerson_Suffix],[Member_ResponsiblePerson_MedicaidNumber]," +
                "[Member_ResponsiblePersonComm_Qualifier_1],[Member_ResponsiblePersonComm_Number_1],[Member_ResponsiblePersonComm_Qualifier_2]," +
                "[Member_ResponsiblePersonComm_Number_2],[Member_ResponsiblePersonComm_Qualifier_3],[Member_ResponsiblePersonComm_Number_3],[HC_HMO_CommunityCareServices_Current]," +
                "[HC_FAC_ProviderCountyCode_Current],[HC_HLT_BenefitCode_Current],[HC_HLT_PrimaryTaxonomy_Current],[Employer Group],[Provider_EntityIdentifier]," +
                "[Provider_EntityType],[Provider_IdentificationCodeQual],[Provider_NPI],[Provider_RelationShip_Code],[Provider_Address],[Provider_City],[Provider_State]," +
                "[Provider_PostalCode],[Provider_ActionCode],[Provider_EntityIdentifierCode],[Provider_EffectiveDate],[Provider_MaintenanceReasonCode],[EPIC_Location_ID]," +
                "[MedicareId],[MedicareEpicId],[MedicareBegin],[MedicareEnd],[PreviousId],[PreviousEpicId],[CaseId],[CaseEpicId],[MedicareDualIndicator]," +
                "[MedicareDualIndicatorEpicId],[MothersMedicaidIdNumber],[MothersMedicaidIdNumberEpicId],[MedicaidRecertification],[MedicaidRecertificationEpicId]," +
                "[ApplicationReceived],[ApplicationReceivedEpicId],[HC_CoveragePeriodBegin_Current],[HC_CoveragePeriodEnd_Current],[HC_CoveragePeriodBegin_Future]," +
                "[HC_HMO_Migrant_Current],[HC_HMO_Migrant_Current_EpicId],[HC_FAC_DentalPlan_Current],[HC_FAC_DentalPlan_Current_EpicId],[HC_HMO_PrenatalPCP_Current]," +
                "[HC_HMO_PrenatalPCP_Current_EpicId],[HC_HMO_MedicaidTypeProgram_Current],[HC_HMO_MedicaidTypeProgram_Current_EpicId],[HC_HMO_MedicaidCategory_Current]," +
                "[HC_HMO_MedicaidCategory_Current_EpicId],[HC_HMO_MedicaidCoverageCode_Current],[HC_HMO_MedicaidCoverageCode_Current_EpicId],[HC_HLT_WaiverTOA_Current]," +
                "[HC_HLT_WaiverTOA_Current_EpicId],[HC_HLT_TiersTOA_Current],[HC_HLT_TiersTOA_Current_EpicId],[HC_FAC_PlanCode_Current],[HC_FAC_PlanCode_Current_EpicId]," +
                "[HC_POS_First_Pregnancy_Current],[HC_POS_First_Pregnancy_Current_EpicId],[HC_POS_PreferredLanguage_Current],[HC_POS_PreferredLanguage_Current_EpicId]," +
                "[HC_POS_ContactPreference_1_Current],[HC_POS_ContactPreference_1_Current_EpicId],[HC_POS_ContactPreference_2_Current],[HC_POS_ContactPreference_2_Current_EpicId]," +
                "[HC_POS_ContactPreference_3_Current],[HC_POS_ContactPreference_3_Current_EpicId]," +
                "[RiskGroup_Current],[RiskGroup_Current_EpicId],[P35_Restorative_Indicator],[P35_Restorative_Indicator_EpicId] " +
                "FROM [TxMedCentral_" + PlanCode + "].[835].[Staging_834]";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Member_STAR_SK_Daily member = new Member_STAR_SK_Daily();
                    member.ReasonType = rdr["ReasonType"] as string;
                    member.ReasonCode = rdr["ReasonCode"] as string;
                    member.BenefitStatus = rdr["BenefitStatus"] as string;
                    member.MedicareStatus = rdr["MedicareStatus"] as string;
                    member.SpecialNeeds = rdr["SpecialNeeds"] as string;
                    member.SSN = rdr["SSN"] as string;
                    member.PolicyNumber = rdr["PolicyNumber"] as string;
                    member.RiskGroup = rdr["RiskGroup"] as string;
                    member.MedicaidId = rdr["MedicaidId"] as string;
                    member.MedicaidCertification = rdr["MedicaidCertification"] as string;
                    member.MedicaidBegin_1 = rdr["MedicaidBegin_1"] as string;
                    member.MedicaidEnd_1 = rdr["MedicaidEnd_1"] as string;
                    member.Member_LastName = rdr["Member_LastName"] as string;
                    member.Member_FirstName = rdr["Member_FirstName"] as string;
                    member.Member_MiddleName = rdr["Member_MiddleName"] as string;
                    member.Member_Prefix = rdr["Member_Prefix"] as string;
                    member.Member_Suffix = rdr["Member_Suffix"] as string;
                    member.Member_Comm_Qualifier_1 = rdr["Member_Comm_Qualifier_1"] as string;
                    member.Member_Comm_Number_1 = rdr["Member_Comm_Number_1"] as string;
                    member.Member_Comm_Qualifier_2 = rdr["Member_Comm_Qualifier_2"] as string;
                    member.Member_Comm_Number_2 = rdr["Member_Comm_Number_2"] as string;
                    member.Member_Comm_Qualifier_3 = rdr["Member_Comm_Qualifier_3"] as string;
                    member.Member_Comm_Number_3 = rdr["Member_Comm_Number_3"] as string;
                    member.Member_Address_1 = rdr["Member_Address_1"] as string;
                    member.Member_Address_2 = rdr["Member_Address_2"] as string;
                    member.Member_City = rdr["Member_City"] as string;
                    member.Member_State = rdr["Member_State"] as string;
                    member.Member_PostalCode = rdr["Member_PostalCode"] as string;
                    member.Member_CountryCode = rdr["Member_CountryCode"] as string;
                    member.Member_CountyCode = rdr["Member_CountyCode"] as string;
                    member.Member_Demographics_BirthDate = rdr["Member_Demographics_BirthDate"] as string;
                    member.Member_Demographics_GenderCode = rdr["Member_Demographics_GenderCode"] as string;
                    member.Member_Demographics_MaritalStatusCode = rdr["Member_Demographics_MaritalStatusCode"] as string;
                    member.Member_Demographics_RaceEthnicityCode = rdr["Member_Demographics_RaceEthnicityCode"] as string;
                    member.Member_Language_IdentificationCode = rdr["Member_Language_IdentificationCode"] as string;
                    member.Member_Language_UseIndicator = rdr["Member_Language_UseIndicator"] as string;
                    member.Member_MailingAddress_1 = rdr["Member_MailingAddress_1"] as string;
                    member.Member_MailingAddress_2 = rdr["Member_MailingAddress_2"] as string;
                    member.Member_MailingCity = rdr["Member_MailingCity"] as string;
                    member.Member_MailingState = rdr["Member_MailingState"] as string;
                    member.Member_MailingPostalCode = rdr["Member_MailingPostalCode"] as string;
                    member.Member_MailingCountryCode = rdr["Member_MailingCountryCode"] as string;
                    member.Member_CustodialParent_LastName = rdr["Member_CustodialParent_LastName"] as string;
                    member.Member_CustodialParent_FirstName = rdr["Member_CustodialParent_FirstName"] as string;
                    member.Member_CustodialParent_MiddleName = rdr["Member_CustodialParent_MiddleName"] as string;
                    member.Member_ResponsiblePerson_LastName = rdr["Member_ResponsiblePerson_LastName"] as string;
                    member.Member_ResponsiblePerson_FirstName = rdr["Member_ResponsiblePerson_FirstName"] as string;
                    member.Member_ResponsiblePerson_MiddleName = rdr["Member_ResponsiblePerson_MiddleName"] as string;
                    member.Member_ResponsiblePerson_Prefix = rdr["Member_ResponsiblePerson_Prefix"] as string;
                    member.Member_ResponsiblePerson_Suffix = rdr["Member_ResponsiblePerson_Suffix"] as string;
                    member.Member_ResponsiblePerson_MedicaidNumber = rdr["Member_ResponsiblePerson_MedicaidNumber"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_1 = rdr["Member_ResponsiblePersonComm_Qualifier_1"] as string;
                    member.Member_ResponsiblePersonComm_Number_1 = rdr["Member_ResponsiblePersonComm_Number_1"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_2 = rdr["Member_ResponsiblePersonComm_Qualifier_2"] as string;
                    member.Member_ResponsiblePersonComm_Number_2 = rdr["Member_ResponsiblePersonComm_Number_2"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_3 = rdr["Member_ResponsiblePersonComm_Qualifier_3"] as string;
                    member.Member_ResponsiblePersonComm_Number_3 = rdr["Member_ResponsiblePersonComm_Number_3"] as string;
                    member.HC_HMO_CommunityCareServices_Current = rdr["HC_HMO_CommunityCareServices_Current"] as string;
                    member.HC_FAC_ProviderCountyCode_Current = rdr["HC_FAC_ProviderCountyCode_Current"] as string;
                    member.HC_HLT_BenefitCode_Current = rdr["HC_HLT_BenefitCode_Current"] as string;
                    member.HC_HLT_PrimaryTaxonomy_Current = rdr["HC_HLT_PrimaryTaxonomy_Current"] as string;
                    member.Employer_Group = rdr["Employer Group"] as string;
                    member.Provider_EntityIdentifier = rdr["Provider_EntityIdentifier"] as string;
                    member.Provider_EntityType = rdr["Provider_EntityType"] as string;
                    member.Provider_IdentificationCodeQual = rdr["Provider_IdentificationCodeQual"] as string;
                    member.Provider_NPI = rdr["Provider_NPI"] as string;
                    member.Provider_RelationShip_Code = rdr["Provider_RelationShip_Code"] as string;
                    member.Provider_Address = rdr["Provider_Address"] as string;
                    member.Provider_City = rdr["Provider_City"] as string;
                    member.Provider_State = rdr["Provider_State"] as string;
                    member.Provider_PostalCode = rdr["Provider_PostalCode"] as string;
                    member.Provider_ActionCode = rdr["Provider_ActionCode"] as string;
                    member.Provider_EntityIdentifierCode = rdr["Provider_EntityIdentifierCode"] as string;
                    member.Provider_EffectiveDate = rdr["Provider_EffectiveDate"] as string;
                    member.Provider_MaintenanceReasonCode = rdr["Provider_MaintenanceReasonCode"] as string;
                    member.EPIC_Location_ID = rdr["EPIC_Location_ID"] as string;
                    member.MedicareId = rdr["MedicareId"] as string;
                    member.MedicareEpicId = rdr["MedicareEpicId"] as string;
                    member.MedicareBegin = rdr["MedicareBegin"] as string;
                    member.MedicareEnd = rdr["MedicareEnd"] as string;
                    member.PreviousId = rdr["PreviousId"] as string;
                    member.PreviousEpicId = rdr["PreviousEpicId"] as string;
                    member.CaseId = rdr["CaseId"] as string;
                    member.CaseEpicId = rdr["CaseEpicId"] as string;
                    member.MedicareDualIndicator = rdr["MedicareDualIndicator"] as string;
                    member.MedicareDualIndicatorEpicId = rdr["MedicareDualIndicatorEpicId"] as string;
                    member.MothersMedicaidIdNumber = rdr["MothersMedicaidIdNumber"] as string;
                    member.MothersMedicaidIdNumberEpicId = rdr["MothersMedicaidIdNumberEpicId"] as string;
                    member.MedicaidRecertification = rdr["MedicaidRecertification"] as string;
                    member.MedicaidRecertificationEpicId = rdr["MedicaidRecertificationEpicId"] as string;
                    member.ApplicationReceived = rdr["ApplicationReceived"] as string;
                    member.ApplicationReceivedEpicId = rdr["ApplicationReceivedEpicId"] as string;
                    member.HC_CoveragePeriodBegin_Current = rdr["HC_CoveragePeriodBegin_Current"] as string;
                    member.HC_CoveragePeriodEnd_Current = rdr["HC_CoveragePeriodEnd_Current"] as string;
                    member.HC_CoveragePeriodBegin_Future = rdr["HC_CoveragePeriodBegin_Future"] as string;
                    member.HC_HMO_Migrant_Current = rdr["HC_HMO_Migrant_Current"] as string;
                    member.HC_HMO_Migrant_Current_EpicId = rdr["HC_HMO_Migrant_Current_EpicId"] as string;
                    member.HC_FAC_DentalPlan_Current = rdr["HC_FAC_DentalPlan_Current"] as string;
                    member.HC_FAC_DentalPlan_Current_EpicId = rdr["HC_FAC_DentalPlan_Current_EpicId"] as string;
                    member.HC_HMO_PrenatalPCP_Current = rdr["HC_HMO_PrenatalPCP_Current"] as string;
                    member.HC_HMO_PrenatalPCP_Current_EpicId = rdr["HC_HMO_PrenatalPCP_Current_EpicId"] as string;
                    member.HC_HMO_MedicaidTypeProgram_Current = rdr["HC_HMO_MedicaidTypeProgram_Current"] as string;
                    member.HC_HMO_MedicaidTypeProgram_Current_EpicId = rdr["HC_HMO_MedicaidTypeProgram_Current_EpicId"] as string;
                    member.HC_HMO_MedicaidCategory_Current = rdr["HC_HMO_MedicaidCategory_Current"] as string;
                    member.HC_HMO_MedicaidCategory_Current_EpicId = rdr["HC_HMO_MedicaidCategory_Current_EpicId"] as string;
                    member.HC_HMO_MedicaidCoverageCode_Current = rdr["HC_HMO_MedicaidCoverageCode_Current"] as string;
                    member.HC_HMO_MedicaidCoverageCode_Current_EpicId = rdr["HC_HMO_MedicaidCoverageCode_Current_EpicId"] as string;
                    member.HC_HLT_WaiverTOA_Current = rdr["HC_HLT_WaiverTOA_Current"] as string;
                    member.HC_HLT_WaiverTOA_Current_EpicId = rdr["HC_HLT_WaiverTOA_Current_EpicId"] as string;
                    member.HC_HLT_TiersTOA_Current = rdr["HC_HLT_TiersTOA_Current"] as string;
                    member.HC_HLT_TiersTOA_Current_EpicId = rdr["HC_HLT_TiersTOA_Current_EpicId"] as string;
                    member.HC_FAC_PlanCode_Current = rdr["HC_FAC_PlanCode_Current"] as string;
                    member.HC_FAC_PlanCode_Current_EpicId = rdr["HC_FAC_PlanCode_Current_EpicId"] as string;
                    member.HC_POS_First_Pregnancy_Current = rdr["HC_POS_First_Pregnancy_Current"] as string;
                    member.HC_POS_First_Pregnancy_Current_EpicId = rdr["HC_POS_First_Pregnancy_Current_EpicId"] as string;
                    member.HC_POS_PreferredLanguage_Current = rdr["HC_POS_PreferredLanguage_Current"] as string;
                    member.HC_POS_PreferredLanguage_Current_EpicId = rdr["HC_POS_PreferredLanguage_Current_EpicId"] as string;
                    member.HC_POS_ContactPreference_1_Current = rdr["HC_POS_ContactPreference_1_Current"] as string;
                    member.HC_POS_ContactPreference_1_Current_EpicId = rdr["HC_POS_ContactPreference_1_Current_EpicId"] as string;
                    member.HC_POS_ContactPreference_2_Current = rdr["HC_POS_ContactPreference_2_Current"] as string;
                    member.HC_POS_ContactPreference_2_Current_EpicId = rdr["HC_POS_ContactPreference_2_Current_EpicId"] as string;
                    member.HC_POS_ContactPreference_3_Current = rdr["HC_POS_ContactPreference_3_Current"] as string;
                    member.HC_POS_ContactPreference_3_Current_EpicId = rdr["HC_POS_ContactPreference_3_Current_EpicId"] as string;
                    member.RiskGroup_Current = rdr["RiskGroup_Current"] as string;
                    member.RiskGroup_Current_EpicId = rdr["RiskGroup_Current_EpicId"] as string;
                    member.P35_Restorative_Indicator = rdr["P35_Restorative_Indicator"] as string;
                    member.P35_Restorative_Indicator_EpicId = rdr["P35_Restorative_Indicator_EpicId"] as string;

                    members.Add(member);
                }
                return members;
            }
        }

        public static List<Member_CHIP> GetMembers_CHIP(String PlanCode)
        {
            List<Member_CHIP> members = new List<Member_CHIP>();

            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_05"].ConnectionString;

            String query = "SELECT [ReasonType],[ReasonCode],[BenefitStatus],[SubscriberStatusCode],[SubscriberIdentifier],[PolicyNumber],[RiskGroup],[CurrEnrollmentMonth]," +
                "[PlanStartDate],[PlanEndDate],[DisenrollmentDate],[Member_LastName],[Member_FirstName],[Member_MiddleName],[Member_Prefix],[Member_Suffix],[Member_SSN]," +
                "[Member_Comm_Qualifier],[Member_Comm_Number],[Member_Address_1],[Member_Address_2],[Member_City],[Member_State],[Member_PostalCode],[Member_CountryCode]," +
                "[Member_CountyCode],[Member_Demographics_BirthDate],[Member_Demographics_GenderCode],[Member_Demographics_MaritalStatusCode]," +
                "[Member_Demographics_RaceEthnicityCode],[Member_MailingAddress_1],[Member_MailingAddress_2],[Member_MailingCity],[Member_MailingState]," +
                "[Member_MailingPostalCode],[Member_ResponsiblePerson_LastName],[Member_ResponsiblePerson_FirstName],[Member_ResponsiblePersonComm_Qualifier_1]," +
                "[Member_ResponsiblePersonComm_Number_1],[Member_ResponsiblePersonComm_Qualifier_2],[Member_ResponsiblePersonComm_Number_2]," +
                "[Member_ResponsiblePersonMailingAddress_LineId],[Member_ResponsiblePersonMailingAddress_1],[Member_ResponsiblePersonMailingAddress_2]," +
                "[Member_ResponsiblePersonMailingCity_LineId],[Member_ResponsiblePersonMailingCity],[Member_ResponsiblePersonMailingState]," +
                "[Member_ResponsiblePersonMailingPostalCode],[HC_HMO_Serious_Health_Problem_Flag],[HC_HMO_Cost_Share_Limit_Flag],[HC_HMO_CHIP_Account_Name_Relationship_Code]," +
                "[HC_HMO_New_Provider_Directory],[HC_HMO_American_Indian_Status],[HC_HMO_CoverageDate],[HC_HMO_Perinatal],[Employer Group],[Provider_EntityIdentifier]," +
                "[Provider_EntityType],[Provider_IdentificationCodeQual],[Provider_NPI],[Provider_RelationShip_Code],[Provider_Address],[Provider_City],[Provider_State]," +
                "[Provider_PostalCode],[Provider_ActionCode],[Provider_EntityIdentifierCode],[Provider_EffectiveDate],[Provider_MaintenanceReasonCode],[EPIC_Location_ID]," +
                "[CaseId],[CaseEpicId],[AnnualEnrollDate],[AnnualEnrollDateEpicId],[DisenrollmentReason],[DisenrollmentReasonEpicId],[HC_CoveragePeriodBegin_Current]," +
                "[HC_CoveragePeriodEnd_Current],[HC_CoveragePeriodBegin_Future],[HC_HMO_Pregnancy_Flag],[HC_HMO_Pregnancy_Flag_EpicId],[HC_HMO_Copayment_Level]," +
                "[HC_HMO_Copayment_Level_EpicId],[HC_HMO_Renewal_Indicator],[HC_HMO_Renewal_Indicator_EpicId],[HC_HMO_DentalPlan],[HC_HMO_DentalPlan_EpicId]," +
                "[RiskGroup_Current],[RiskGroup_Current_EpicId],[RiskGroup_Future],[RiskGroup_Future_EpicId] FROM [TxMedCentral_" + PlanCode + "].[834].[Staging_834]";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Member_CHIP member = new Member_CHIP();
                    member.ReasonType = rdr["ReasonType"] as string;
                    member.ReasonCode = rdr["ReasonCode"] as string;
                    member.BenefitStatus = rdr["BenefitStatus"] as string;
                    member.SubscriberStatusCode = rdr["SubscriberStatusCode"] as string;
                    member.SubscriberIdentifier = rdr["SubscriberIdentifier"] as string;
                    member.PolicyNumber = rdr["PolicyNumber"] as string;
                    member.RiskGroup = rdr["RiskGroup"] as string;
                    member.CurrEnrollmentMonth = rdr["CurrEnrollmentMonth"] as string;
                    member.PlanStartDate = rdr["PlanStartDate"] as string;
                    member.PlanEndDate = rdr["PlanEndDate"] as string;
                    member.DisenrollmentDate = rdr["DisenrollmentDate"] as string;
                    member.Member_LastName = rdr["Member_LastName"] as string;
                    member.Member_FirstName = rdr["Member_FirstName"] as string;
                    member.Member_MiddleName = rdr["Member_MiddleName"] as string;
                    member.Member_Prefix = rdr["Member_Prefix"] as string;
                    member.Member_Suffix = rdr["Member_Suffix"] as string;
                    member.Member_SSN = rdr["Member_SSN"] as string;
                    member.Member_Comm_Qualifier = rdr["Member_Comm_Qualifier"] as string;
                    member.Member_Comm_Number = rdr["Member_Comm_Number"] as string;
                    member.Member_Address_1 = rdr["Member_Address_1"] as string;
                    member.Member_Address_2 = rdr["Member_Address_2"] as string;
                    member.Member_City = rdr["Member_City"] as string;
                    member.Member_State = rdr["Member_State"] as string;
                    member.Member_PostalCode = rdr["Member_PostalCode"] as string;
                    member.Member_CountryCode = rdr["Member_CountryCode"] as string;
                    member.Member_CountyCode = rdr["Member_CountyCode"] as string;
                    member.Member_Demographics_BirthDate = rdr["Member_Demographics_BirthDate"] as string;
                    member.Member_Demographics_GenderCode = rdr["Member_Demographics_GenderCode"] as string;
                    member.Member_Demographics_MaritalStatusCode = rdr["Member_Demographics_MaritalStatusCode"] as string;
                    member.Member_Demographics_RaceEthnicityCode = rdr["Member_Demographics_RaceEthnicityCode"] as string;
                    member.Member_MailingAddress_1 = rdr["Member_MailingAddress_1"] as string;
                    member.Member_MailingAddress_2 = rdr["Member_MailingAddress_2"] as string;
                    member.Member_MailingCity = rdr["Member_MailingCity"] as string;
                    member.Member_MailingState = rdr["Member_MailingState"] as string;
                    member.Member_MailingPostalCode = rdr["Member_MailingPostalCode"] as string;
                    member.Member_ResponsiblePerson_LastName = rdr["Member_ResponsiblePerson_LastName"] as string;
                    member.Member_ResponsiblePerson_FirstName = rdr["Member_ResponsiblePerson_FirstName"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_1 = rdr["Member_ResponsiblePersonComm_Qualifier_1"] as string;
                    member.Member_ResponsiblePersonComm_Number_1 = rdr["Member_ResponsiblePersonComm_Number_1"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_2 = rdr["Member_ResponsiblePersonComm_Qualifier_2"] as string;
                    member.Member_ResponsiblePersonComm_Number_2 = rdr["Member_ResponsiblePersonComm_Number_2"] as string;
                    member.Member_ResponsiblePersonMailingAddress_LineId = rdr["Member_ResponsiblePersonMailingAddress_LineId"] as string;
                    member.Member_ResponsiblePersonMailingAddress_1 = rdr["Member_ResponsiblePersonMailingAddress_1"] as string;
                    member.Member_ResponsiblePersonMailingAddress_2 = rdr["Member_ResponsiblePersonMailingAddress_2"] as string;
                    member.Member_ResponsiblePersonMailingCity_LineId = rdr["Member_ResponsiblePersonMailingCity_LineId"] as string;
                    member.Member_ResponsiblePersonMailingCity = rdr["Member_ResponsiblePersonMailingCity"] as string;
                    member.Member_ResponsiblePersonMailingState = rdr["Member_ResponsiblePersonMailingState"] as string;
                    member.Member_ResponsiblePersonMailingPostalCode = rdr["Member_ResponsiblePersonMailingPostalCode"] as string;
                    member.HC_HMO_Serious_Health_Problem_Flag = rdr["HC_HMO_Serious_Health_Problem_Flag"] as string;
                    member.HC_HMO_Cost_Share_Limit_Flag = rdr["HC_HMO_Cost_Share_Limit_Flag"] as string;
                    member.HC_HMO_CHIP_Account_Name_Relationship_Code = rdr["HC_HMO_CHIP_Account_Name_Relationship_Code"] as string;
                    member.HC_HMO_New_Provider_Directory = rdr["HC_HMO_New_Provider_Directory"] as string;
                    member.HC_HMO_American_Indian_Status = rdr["HC_HMO_American_Indian_Status"] as string;
                    member.HC_HMO_CoverageDate = rdr["HC_HMO_CoverageDate"] as string;
                    member.HC_HMO_Perinatal = rdr["HC_HMO_Perinatal"] as string;
                    member.Employer_Group = rdr["Employer Group"] as string;
                    member.Provider_EntityIdentifier = rdr["Provider_EntityIdentifier"] as string;
                    member.Provider_EntityType = rdr["Provider_EntityType"] as string;
                    member.Provider_IdentificationCodeQual = rdr["Provider_IdentificationCodeQual"] as string;
                    member.Provider_NPI = rdr["Provider_NPI"] as string;
                    member.Provider_RelationShip_Code = rdr["Provider_RelationShip_Code"] as string;
                    member.Provider_Address = rdr["Provider_Address"] as string;
                    member.Provider_City = rdr["Provider_City"] as string;
                    member.Provider_State = rdr["Provider_State"] as string;
                    member.Provider_PostalCode = rdr["Provider_PostalCode"] as string;
                    member.Provider_ActionCode = rdr["Provider_ActionCode"] as string;
                    member.Provider_EntityIdentifierCode = rdr["Provider_EntityIdentifierCode"] as string;
                    member.Provider_EffectiveDate = rdr["Provider_EffectiveDate"] as string;
                    member.Provider_MaintenanceReasonCode = rdr["Provider_MaintenanceReasonCode"] as string;
                    member.EPIC_Location_ID = rdr["EPIC_Location_ID"] as string;
                    member.CaseId = rdr["CaseId"] as string;
                    member.CaseEpicId = rdr["CaseEpicId"] as string;
                    member.AnnualEnrollDate = rdr["AnnualEnrollDate"] as string;
                    member.AnnualEnrollDateEpicId = rdr["AnnualEnrollDateEpicId"] as string;
                    member.DisenrollmentReason = rdr["DisenrollmentReason"] as string;
                    member.DisenrollmentReasonEpicId = rdr["DisenrollmentReasonEpicId"] as string;
                    member.HC_CoveragePeriodBegin_Current = rdr["HC_CoveragePeriodBegin_Current"] as string;
                    member.HC_CoveragePeriodEnd_Current = rdr["HC_CoveragePeriodEnd_Current"] as string;
                    member.HC_CoveragePeriodBegin_Future = rdr["HC_CoveragePeriodBegin_Future"] as string;
                    member.HC_HMO_Pregnancy_Flag = rdr["HC_HMO_Pregnancy_Flag"] as string;
                    member.HC_HMO_Pregnancy_Flag_EpicId = rdr["HC_HMO_Pregnancy_Flag_EpicId"] as string;
                    member.HC_HMO_Copayment_Level = rdr["HC_HMO_Copayment_Level"] as string;
                    member.HC_HMO_Copayment_Level_EpicId = rdr["HC_HMO_Copayment_Level_EpicId"] as string;
                    member.HC_HMO_Renewal_Indicator = rdr["HC_HMO_Renewal_Indicator"] as string;
                    member.HC_HMO_Renewal_Indicator_EpicId = rdr["HC_HMO_Renewal_Indicator_EpicId"] as string;
                    member.HC_HMO_DentalPlan = rdr["HC_HMO_DentalPlan"] as string;
                    member.HC_HMO_DentalPlan_EpicId = rdr["HC_HMO_DentalPlan_EpicId"] as string;
                    member.RiskGroup_Current = rdr["RiskGroup_Current"] as string;
                    member.RiskGroup_Current_EpicId = rdr["RiskGroup_Current_EpicId"] as string;
                    member.RiskGroup_Future = rdr["RiskGroup_Future"] as string;
                    member.RiskGroup_Future_EpicId = rdr["RiskGroup_Future_EpicId"] as string;

                    members.Add(member);
                }
                return members;
            }
        }

        public static List<Member_CHIP> GetMembers_CHIP_Daily(String PlanCode)
        {
            List<Member_CHIP> members = new List<Member_CHIP>();

            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TxMedCentral_05"].ConnectionString;

            String query = "SELECT [ReasonType],[ReasonCode],[BenefitStatus],[SubscriberStatusCode],[SubscriberIdentifier],[PolicyNumber],[RiskGroup],[CurrEnrollmentMonth]," +
                "[PlanStartDate],[PlanEndDate],[DisenrollmentDate],[Member_LastName],[Member_FirstName],[Member_MiddleName],[Member_Prefix],[Member_Suffix],[Member_SSN]," +
                "[Member_Comm_Qualifier],[Member_Comm_Number],[Member_Address_1],[Member_Address_2],[Member_City],[Member_State],[Member_PostalCode],[Member_CountryCode]," +
                "[Member_CountyCode],[Member_Demographics_BirthDate],[Member_Demographics_GenderCode],[Member_Demographics_MaritalStatusCode]," +
                "[Member_Demographics_RaceEthnicityCode],[Member_MailingAddress_1],[Member_MailingAddress_2],[Member_MailingCity],[Member_MailingState]," +
                "[Member_MailingPostalCode],[Member_ResponsiblePerson_LastName],[Member_ResponsiblePerson_FirstName],[Member_ResponsiblePersonComm_Qualifier_1]," +
                "[Member_ResponsiblePersonComm_Number_1],[Member_ResponsiblePersonComm_Qualifier_2],[Member_ResponsiblePersonComm_Number_2]," +
                "[Member_ResponsiblePersonMailingAddress_1],[Member_ResponsiblePersonMailingAddress_2],[Member_ResponsiblePersonMailingCity],[Member_ResponsiblePersonMailingState]," +
                "[Member_ResponsiblePersonMailingPostalCode],[HC_HMO_Serious_Health_Problem_Flag],[HC_HMO_Cost_Share_Limit_Flag],[HC_HMO_CHIP_Account_Name_Relationship_Code]," +
                "[HC_HMO_New_Provider_Directory],[HC_HMO_American_Indian_Status],[HC_HMO_CoverageDate],[HC_HMO_Perinatal],[Employer Group],[Provider_EntityIdentifier]," +
                "[Provider_EntityType],[Provider_IdentificationCodeQual],[Provider_NPI],[Provider_RelationShip_Code],[Provider_Address],[Provider_City],[Provider_State]," +
                "[Provider_PostalCode],[Provider_ActionCode],[Provider_EntityIdentifierCode],[Provider_EffectiveDate],[Provider_MaintenanceReasonCode],[EPIC_Location_ID]," +
                "[CaseId],[CaseEpicId],[AnnualEnrollDate],[AnnualEnrollDateEpicId],[DisenrollmentReason],[DisenrollmentReasonEpicId],[HC_CoveragePeriodBegin_Current]," +
                "[HC_CoveragePeriodEnd_Current],[HC_CoveragePeriodBegin_Future],[HC_HMO_Pregnancy_Flag],[HC_HMO_Pregnancy_Flag_EpicId],[HC_HMO_Copayment_Level]," +
                "[HC_HMO_Copayment_Level_EpicId],[HC_HMO_Renewal_Indicator],[HC_HMO_Renewal_Indicator_EpicId],[HC_HMO_DentalPlan],[HC_HMO_DentalPlan_EpicId]," +
                "[RiskGroup_Current],[RiskGroup_Current_EpicId] FROM [TxMedCentral_" + PlanCode + "].[835].[Staging_834]";

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Member_CHIP member = new Member_CHIP();
                    member.ReasonType = rdr["ReasonType"] as string;
                    member.ReasonCode = rdr["ReasonCode"] as string;
                    member.BenefitStatus = rdr["BenefitStatus"] as string;
                    member.SubscriberStatusCode = rdr["SubscriberStatusCode"] as string;
                    member.SubscriberIdentifier = rdr["SubscriberIdentifier"] as string;
                    member.PolicyNumber = rdr["PolicyNumber"] as string;
                    member.RiskGroup = rdr["RiskGroup"] as string;
                    member.CurrEnrollmentMonth = rdr["CurrEnrollmentMonth"] as string;
                    member.PlanStartDate = rdr["PlanStartDate"] as string;
                    member.PlanEndDate = rdr["PlanEndDate"] as string;
                    member.DisenrollmentDate = rdr["DisenrollmentDate"] as string;
                    member.Member_LastName = rdr["Member_LastName"] as string;
                    member.Member_FirstName = rdr["Member_FirstName"] as string;
                    member.Member_MiddleName = rdr["Member_MiddleName"] as string;
                    member.Member_Prefix = rdr["Member_Prefix"] as string;
                    member.Member_Suffix = rdr["Member_Suffix"] as string;
                    member.Member_SSN = rdr["Member_SSN"] as string;
                    member.Member_Comm_Qualifier = rdr["Member_Comm_Qualifier"] as string;
                    member.Member_Comm_Number = rdr["Member_Comm_Number"] as string;
                    member.Member_Address_1 = rdr["Member_Address_1"] as string;
                    member.Member_Address_2 = rdr["Member_Address_2"] as string;
                    member.Member_City = rdr["Member_City"] as string;
                    member.Member_State = rdr["Member_State"] as string;
                    member.Member_PostalCode = rdr["Member_PostalCode"] as string;
                    member.Member_CountryCode = rdr["Member_CountryCode"] as string;
                    member.Member_CountyCode = rdr["Member_CountyCode"] as string;
                    member.Member_Demographics_BirthDate = rdr["Member_Demographics_BirthDate"] as string;
                    member.Member_Demographics_GenderCode = rdr["Member_Demographics_GenderCode"] as string;
                    member.Member_Demographics_MaritalStatusCode = rdr["Member_Demographics_MaritalStatusCode"] as string;
                    member.Member_Demographics_RaceEthnicityCode = rdr["Member_Demographics_RaceEthnicityCode"] as string;
                    member.Member_MailingAddress_1 = rdr["Member_MailingAddress_1"] as string;
                    member.Member_MailingAddress_2 = rdr["Member_MailingAddress_2"] as string;
                    member.Member_MailingCity = rdr["Member_MailingCity"] as string;
                    member.Member_MailingState = rdr["Member_MailingState"] as string;
                    member.Member_MailingPostalCode = rdr["Member_MailingPostalCode"] as string;
                    member.Member_ResponsiblePerson_LastName = rdr["Member_ResponsiblePerson_LastName"] as string;
                    member.Member_ResponsiblePerson_FirstName = rdr["Member_ResponsiblePerson_FirstName"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_1 = rdr["Member_ResponsiblePersonComm_Qualifier_1"] as string;
                    member.Member_ResponsiblePersonComm_Number_1 = rdr["Member_ResponsiblePersonComm_Number_1"] as string;
                    member.Member_ResponsiblePersonComm_Qualifier_2 = rdr["Member_ResponsiblePersonComm_Qualifier_2"] as string;
                    member.Member_ResponsiblePersonComm_Number_2 = rdr["Member_ResponsiblePersonComm_Number_2"] as string;
                    member.Member_ResponsiblePersonMailingAddress_1 = rdr["Member_ResponsiblePersonMailingAddress_1"] as string;
                    member.Member_ResponsiblePersonMailingAddress_2 = rdr["Member_ResponsiblePersonMailingAddress_2"] as string;
                    member.Member_ResponsiblePersonMailingCity = rdr["Member_ResponsiblePersonMailingCity"] as string;
                    member.Member_ResponsiblePersonMailingState = rdr["Member_ResponsiblePersonMailingState"] as string;
                    member.Member_ResponsiblePersonMailingPostalCode = rdr["Member_ResponsiblePersonMailingPostalCode"] as string;
                    member.HC_HMO_Serious_Health_Problem_Flag = rdr["HC_HMO_Serious_Health_Problem_Flag"] as string;
                    member.HC_HMO_Cost_Share_Limit_Flag = rdr["HC_HMO_Cost_Share_Limit_Flag"] as string;
                    member.HC_HMO_CHIP_Account_Name_Relationship_Code = rdr["HC_HMO_CHIP_Account_Name_Relationship_Code"] as string;
                    member.HC_HMO_New_Provider_Directory = rdr["HC_HMO_New_Provider_Directory"] as string;
                    member.HC_HMO_American_Indian_Status = rdr["HC_HMO_American_Indian_Status"] as string;
                    member.HC_HMO_CoverageDate = rdr["HC_HMO_CoverageDate"] as string;
                    member.HC_HMO_Perinatal = rdr["HC_HMO_Perinatal"] as string;
                    member.Employer_Group = rdr["Employer Group"] as string;
                    member.Provider_EntityIdentifier = rdr["Provider_EntityIdentifier"] as string;
                    member.Provider_EntityType = rdr["Provider_EntityType"] as string;
                    member.Provider_IdentificationCodeQual = rdr["Provider_IdentificationCodeQual"] as string;
                    member.Provider_NPI = rdr["Provider_NPI"] as string;
                    member.Provider_RelationShip_Code = rdr["Provider_RelationShip_Code"] as string;
                    member.Provider_Address = rdr["Provider_Address"] as string;
                    member.Provider_City = rdr["Provider_City"] as string;
                    member.Provider_State = rdr["Provider_State"] as string;
                    member.Provider_PostalCode = rdr["Provider_PostalCode"] as string;
                    member.Provider_ActionCode = rdr["Provider_ActionCode"] as string;
                    member.Provider_EntityIdentifierCode = rdr["Provider_EntityIdentifierCode"] as string;
                    member.Provider_EffectiveDate = rdr["Provider_EffectiveDate"] as string;
                    member.Provider_MaintenanceReasonCode = rdr["Provider_MaintenanceReasonCode"] as string;
                    member.EPIC_Location_ID = rdr["EPIC_Location_ID"] as string;
                    member.CaseId = rdr["CaseId"] as string;
                    member.CaseEpicId = rdr["CaseEpicId"] as string;
                    member.AnnualEnrollDate = rdr["AnnualEnrollDate"] as string;
                    member.AnnualEnrollDateEpicId = rdr["AnnualEnrollDateEpicId"] as string;
                    member.DisenrollmentReason = rdr["DisenrollmentReason"] as string;
                    member.DisenrollmentReasonEpicId = rdr["DisenrollmentReasonEpicId"] as string;
                    member.HC_CoveragePeriodBegin_Current = rdr["HC_CoveragePeriodBegin_Current"] as string;
                    member.HC_CoveragePeriodEnd_Current = rdr["HC_CoveragePeriodEnd_Current"] as string;
                    member.HC_CoveragePeriodBegin_Future = rdr["HC_CoveragePeriodBegin_Future"] as string;
                    member.HC_HMO_Pregnancy_Flag = rdr["HC_HMO_Pregnancy_Flag"] as string;
                    member.HC_HMO_Pregnancy_Flag_EpicId = rdr["HC_HMO_Pregnancy_Flag_EpicId"] as string;
                    member.HC_HMO_Copayment_Level = rdr["HC_HMO_Copayment_Level"] as string;
                    member.HC_HMO_Copayment_Level_EpicId = rdr["HC_HMO_Copayment_Level_EpicId"] as string;
                    member.HC_HMO_Renewal_Indicator = rdr["HC_HMO_Renewal_Indicator"] as string;
                    member.HC_HMO_Renewal_Indicator_EpicId = rdr["HC_HMO_Renewal_Indicator_EpicId"] as string;
                    member.HC_HMO_DentalPlan = rdr["HC_HMO_DentalPlan"] as string;
                    member.HC_HMO_DentalPlan_EpicId = rdr["HC_HMO_DentalPlan_EpicId"] as string;
                    member.RiskGroup_Current = rdr["RiskGroup_Current"] as string;
                    member.RiskGroup_Current_EpicId = rdr["RiskGroup_Current_EpicId"] as string;

                    members.Add(member);
                }
                return members;
            }
        }

        public static List<string> Header834(String PlanCode)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            List<string> text834 = new List<string>();

            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DHP_Custom_Library"].ConnectionString;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("[834].[Header834]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PlanCode", PlanCode));

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    text834.Add((rdr["Line"] as string) + "~");
                }

                return text834;
            }
        }

        public static List<string> Header834_Daily(String PlanCode)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            List<string> text834 = new List<string>();

            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DHP_Custom_Library"].ConnectionString;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("[834].[Header834_Daily]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PlanCode", PlanCode));

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    text834.Add((rdr["Line"] as string) + "~");
                }

                return text834;
            }
        }

        public static List<string> Footer834(String PlanCode)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            List<string> text834 = new List<string>();

            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DHP_Custom_Library"].ConnectionString;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("[834].[Footer834]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PlanCode", PlanCode));

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    text834.Add((rdr["Line"] as string) + "~");
                }

                return text834;
            }
        }

        public static List<string> Footer834_Daily(String PlanCode)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            List<string> text834 = new List<string>();

            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DHP_Custom_Library"].ConnectionString;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("[834].[Footer834_Daily]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@PlanCode", PlanCode));

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    text834.Add((rdr["Line"] as string) + "~");
                }

                return text834;
            }
        }

        public static string GetFileName(String PlanCode)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            string query = "SELECT TOP 1 [FILE NAME] FROM [TxMedCentral_" + PlanCode + "].[834].[Staging_834]";

            string fileName = "";

            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DHP_Custom_Library"].ConnectionString;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@PlanCode", PlanCode));

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fileName = rdr["FILE NAME"] as string;
                }

                return fileName;
            }
        }

        public static string GetFileName_Daily(String PlanCode)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            string query = "SELECT TOP 1 [FILE NAME] FROM [TxMedCentral_" + PlanCode + "].[835].[Staging_834]";

            string fileName = "";

            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DHP_Custom_Library"].ConnectionString;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@PlanCode", PlanCode));

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fileName = rdr["FILE NAME"] as string;
                }

                return fileName;
            }
        }
    }    
}

