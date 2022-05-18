using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build834.Models
{
    public class Member_STAR_SK
    {
      public string ReasonType { get; set; }
      public string ReasonCode { get; set; }
      public string BenefitStatus { get; set; }
      public string MedicareStatus { get; set; }
      public string SpecialNeeds { get; set; }
      public string SSN { get; set; }
      public string SSN_LineId { get; set; }
      public string PolicyNumber { get; set; }
      public string RiskGroup { get; set; }
      public string MedicaidId { get; set; }
      public string MedicaidCertification { get; set; }
      public string MedicaidBegin_1 { get; set; }
      public string MedicaidEnd_1 { get; set; }
      public string MedicaidBegin_2 { get; set; }
      public string Member_LastName { get; set; }
      public string Member_FirstName { get; set; }
      public string Member_MiddleName { get; set; }
      public string Member_Prefix { get; set; }
      public string Member_Suffix { get; set; }
      public string Member_Comm_Qualifier_1 { get; set; }
      public string Member_Comm_Number_1 { get; set; }
      public string Member_Comm_Qualifier_2 { get; set; }
      public string Member_Comm_Number_2 { get; set; }
      public string Member_Comm_Qualifier_3 { get; set; }
      public string Member_Comm_Number_3 { get; set; }
      public string Member_Address_1 { get; set; }
      public string Member_Address_2 { get; set; }
      public string Member_City { get; set; }
      public string Member_State { get; set; }
      public string Member_PostalCode { get; set; }
      public string Member_CountryCode { get; set; }
      public string Member_CountyCode { get; set; }
      public string Member_Demographics_BirthDate { get; set; }
      public string Member_Demographics_GenderCode { get; set; }
      public string Member_Demographics_MaritalStatusCode { get; set; }
      public string Member_Demographics_RaceEthnicityCode { get; set; }
      public string Member_Language_IdentificationCode { get; set; }
      public string Member_Language_UseIndicator { get; set; }
      public string Member_MailingAddress_1 { get; set; }
      public string Member_MailingAddress_2 { get; set; }
      public string Member_MailingCity { get; set; }
      public string Member_MailingState { get; set; }
      public string Member_MailingPostalCode { get; set; }
      public string Member_MailingCountryCode { get; set; }
      public string Member_CustodialParent_LastName { get; set; }
      public string Member_CustodialParent_FirstName { get; set; }
      public string Member_CustodialParent_MiddleName { get; set; }
      public string Member_ResponsiblePerson_LastName { get; set; }
      public string Member_ResponsiblePerson_FirstName { get; set; }
      public string Member_ResponsiblePerson_MiddleName { get; set; }
      public string Member_ResponsiblePerson_Prefix { get; set; }
      public string Member_ResponsiblePerson_Suffix { get; set; }
      public string Member_ResponsiblePerson_MedicaidNumber { get; set; }
      public string Member_ResponsiblePersonComm_Qualifier_1 { get; set; }
      public string Member_ResponsiblePersonComm_Number_1 { get; set; }
      public string Member_ResponsiblePersonComm_Qualifier_2 { get; set; }
      public string Member_ResponsiblePersonComm_Number_2 { get; set; }
      public string Member_ResponsiblePersonComm_Qualifier_3 { get; set; }
      public string Member_ResponsiblePersonComm_Number_3 { get; set; }
      public string Employer_Group { get; set; }
      public string Provider_EntityIdentifier { get; set; }
      public string Provider_EntityType { get; set; }
      public string Provider_IdentificationCodeQual { get; set; }
      public string Provider_NPI { get; set; }
      public string Provider_RelationShip_Code { get; set; }
      public string Provider_Address { get; set; }
      public string Provider_City { get; set; }
      public string Provider_State { get; set; }
      public string Provider_PostalCode { get; set; }
      public string Provider_ActionCode { get; set; }
      public string Provider_EntityIdentifierCode { get; set; }
      public string Provider_EffectiveDate { get; set; }
      public string Provider_MaintenanceReasonCode { get; set; }
      public string EPIC_Location_ID { get; set; }
      public string MedicareId { get; set; }
      public string MedicareEpicId { get; set; }
      public string MedicareBegin { get; set; }
      public string MedicareEnd { get; set; }
      public string PreviousId { get; set; }
      public string PreviousEpicId { get; set; }
      public string CaseId { get; set; }
      public string CaseEpicId { get; set; }
      public string MedicareDualIndicator { get; set; }
      public string MedicareDualIndicatorEpicId { get; set; }
      public string MothersMedicaidIdNumber { get; set; }
      public string MothersMedicaidIdNumberEpicId { get; set; }
      public string MedicaidRecertification { get; set; }
      public string MedicaidRecertificationEpicId { get; set; }
      public string ApplicationReceived { get; set; }
      public string ApplicationReceivedEpicId { get; set; }
      public string HC_CoveragePeriodBegin_Current { get; set; }
      public string HC_CoveragePeriodEnd_Current { get; set; }
      public string HC_CoveragePeriodBegin_Future { get; set; }
      public string HC_HMO_Migrant_Current { get; set; }
      public string HC_HMO_Migrant_Current_EpicId { get; set; }
      public string HC_HMO_Migrant_Future { get; set; }
      public string HC_HMO_Migrant_Future_EpicId { get; set; }
      public string HC_FAC_DentalPlan_Current { get; set; }
      public string HC_FAC_DentalPlan_Current_EpicId { get; set; }
      public string HC_FAC_DentalPlan_Future { get; set; }
      public string HC_FAC_DentalPlan_Future_EpicId { get; set; }
      public string HC_HMO_PrenatalPCP_Current { get; set; }
      public string HC_HMO_PrenatalPCP_Current_EpicId { get; set; }
      public string HC_HMO_PrenatalPCP_Future { get; set; }
      public string HC_HMO_PrenatalPCP_Future_EpicId { get; set; }
      public string HC_HMO_MedicaidTypeProgram_Current { get; set; }
      public string HC_HMO_MedicaidTypeProgram_Current_EpicId { get; set; }
      public string HC_HMO_MedicaidTypeProgram_Future { get; set; }
      public string HC_HMO_MedicaidTypeProgram_Future_EpicId { get; set; }
      public string HC_HMO_MedicaidCategory_Current { get; set; }
      public string HC_HMO_MedicaidCategory_Current_EpicId { get; set; }
      public string HC_HMO_MedicaidCategory_Future { get; set; }
      public string HC_HMO_MedicaidCategory_Future_EpicId { get; set; }
      public string HC_HMO_MedicaidCoverageCode_Current { get; set; }
      public string HC_HMO_MedicaidCoverageCode_Current_EpicId { get; set; }
      public string HC_HMO_MedicaidCoverageCode_Future { get; set; }
      public string HC_HMO_MedicaidCoverageCode_Future_EpicId { get; set; }
      public string HC_HLT_WaiverTOA_Current { get; set; }
      public string HC_HLT_WaiverTOA_Current_EpicId { get; set; }
      public string HC_HLT_WaiverTOA_Future { get; set; }
      public string HC_HLT_WaiverTOA_Future_EpicId { get; set; }
      public string HC_HLT_TiersTOA_Current { get; set; }
      public string HC_HLT_TiersTOA_Current_EpicId { get; set; }
      public string HC_HLT_TiersTOA_Future { get; set; }
      public string HC_HLT_TiersTOA_Future_EpicId { get; set; }
      public string HC_FAC_PlanCode_Current { get; set; }
      public string HC_FAC_PlanCode_Current_EpicId { get; set; }
      public string HC_FAC_PlanCode_Future { get; set; }
      public string HC_FAC_PlanCode_Future_EpicId { get; set; }
      public string HC_POS_First_Pregnancy_Current { get; set; }
      public string HC_POS_First_Pregnancy_Current_EpicId { get; set; }
      public string HC_POS_PreferredLanguage_Current { get; set; }
      public string HC_POS_PreferredLanguage_Current_EpicId { get; set; }
      public string HC_POS_ContactPreference_1_Current { get; set; }
      public string HC_POS_ContactPreference_1_Current_EpicId { get; set; }
      public string HC_POS_ContactPreference_2_Current { get; set; }
      public string HC_POS_ContactPreference_2_Current_EpicId { get; set; }
      public string HC_POS_ContactPreference_3_Current { get; set; }
      public string HC_POS_ContactPreference_3_Current_EpicId { get; set; }
      public string RiskGroup_Current { get; set; }
      public string RiskGroup_Current_EpicId { get; set; }
      public string RiskGroup_Future { get; set; }
      public string RiskGroup_Future_EpicId { get; set; }

      public bool Member_Name_Equals_Responsible_Party_Name()
        {
            return Member_LastName == Member_ResponsiblePerson_LastName 
                && Member_FirstName == Member_ResponsiblePerson_FirstName 
                && Member_MiddleName == Member_ResponsiblePerson_MiddleName;
        }

      public int Member_Age()
        {
            DateTime now = DateTime.Today; 
             DateTime memberDOB = DateTime.ParseExact(Member_Demographics_BirthDate, "yyyyMMdd", null);

            int age = now.Year - memberDOB.Year;

            if (now.Month < memberDOB.Month || (now.Month == memberDOB.Month && now.Day < memberDOB.Day))
                age--;

            return age;

        }
    }
}
