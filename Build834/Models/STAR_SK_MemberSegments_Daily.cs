using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build834.Models
{
    public class STAR_SK_MemberSegments_Daily
    {

        public static List<string> BuildMemberSegments(Member_STAR_SK_Daily member, string PlanCode)
        {
            List<string> memberSegment = new List<string>();

            memberSegment.Add(INSSegment(member));
            memberSegment.Add(REF0F(member));
            memberSegment.Add(REF1L(member));
            memberSegment.Add(REF23(member));
            memberSegment.Add(REFZZ(member));
            memberSegment.Add(NM1IL(member));
            memberSegment.Add(PERIP(member));
            memberSegment.Add(N3Member(member));
            memberSegment.Add(N4Member(member));
            memberSegment.Add(DMGD8(member));
            if(!string.IsNullOrEmpty(member.Member_Language_IdentificationCode) || !string.IsNullOrEmpty(member.Member_Language_UseIndicator))
            {
                memberSegment.Add(LUI(member));
            }
            memberSegment.Add(NM131());
            memberSegment.Add(N3Mailing(member));
            memberSegment.Add(N4Mailing(member));
            if (!string.IsNullOrEmpty(member.Member_CustodialParent_LastName))
            {
                memberSegment.Add(NM1S3(member));
            }
            memberSegment.Add(NM1QD(member));
            if (!string.IsNullOrEmpty(member.Member_ResponsiblePersonComm_Qualifier_1) || !string.IsNullOrEmpty(member.Member_ResponsiblePersonComm_Number_1))
            {
                memberSegment.Add(PERRP(member));
            }
            memberSegment.AddRange(HD021_or_HD024(member, PlanCode));
            memberSegment.AddRange(LX1(member));
            memberSegment.AddRange(LX2(member));
            
            return memberSegment;
        }

        private static string INSSegment(Member_STAR_SK_Daily member)
        {
            return "INS*Y*18*" + member.ReasonType + "*" + member.ReasonCode + "*" + member.BenefitStatus + "*" + member.MedicareStatus + "**AC**" + member.SpecialNeeds + "~";
        }

        private static string REF0F(Member_STAR_SK_Daily member)
        {
            return "REF*0F*" + member.MedicaidId + "~";
        }

        private static string REF1L(Member_STAR_SK_Daily member)
        {
            return "REF*1L*" + member.Employer_Group + "~";
        }

        private static string REF23(Member_STAR_SK_Daily member)
        {
            return "REF*23*" + member.MedicaidId + "~";
        }

        private static string REFZZ(Member_STAR_SK_Daily member)
        {
            string refzz = "REF*ZZ*";

            if(!string.IsNullOrEmpty(member.MedicareId))
            {
                refzz += member.MedicareEpicId + "|||" + member.MedicareId + ";";  
            }

            if(!string.IsNullOrEmpty(member.CaseId))
            {
                refzz += member.CaseEpicId + "|||" + member.CaseId + ";";
            }

            if (!string.IsNullOrEmpty(member.MedicareDualIndicator))
            {
                refzz += member.MedicareDualIndicatorEpicId + "|||" + member.MedicareDualIndicator + ";";
            }

            if (!string.IsNullOrEmpty(member.MothersMedicaidIdNumber))
            {
                refzz += member.MothersMedicaidIdNumberEpicId + "|||" + member.MothersMedicaidIdNumber + ";";
            }

            if (!string.IsNullOrEmpty(member.MedicaidRecertification))
            {
                // 2-11-19 | Moved from eff date to comment section due to cov attr failing when eff date < current date
                refzz += member.MedicaidRecertificationEpicId + "|||" + member.MedicaidRecertification + ";";
            }

            if (!string.IsNullOrEmpty(member.ApplicationReceived))
            {
                refzz += member.ApplicationReceivedEpicId + "|||" + member.ApplicationReceived + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_Migrant_Current))
            {
                refzz += member.HC_HMO_Migrant_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "||" + member.HC_HMO_Migrant_Current + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_FAC_DentalPlan_Current))
            {
                refzz += member.HC_FAC_DentalPlan_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "||" + member.HC_FAC_DentalPlan_Current + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_PrenatalPCP_Current))
            {
                refzz += member.HC_HMO_PrenatalPCP_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "||" + member.HC_HMO_PrenatalPCP_Current + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_MedicaidTypeProgram_Current_EpicId))
            {
                refzz += member.HC_HMO_MedicaidTypeProgram_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "|" + member.HC_CoveragePeriodEnd_Current + "|" + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_MedicaidCategory_Current_EpicId))
            {
                refzz += member.HC_HMO_MedicaidCategory_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "|" + member.HC_CoveragePeriodEnd_Current + "|" + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_MedicaidCoverageCode_Current_EpicId))
            {
                refzz += member.HC_HMO_MedicaidCoverageCode_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "|" + member.HC_CoveragePeriodEnd_Current + "|" + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HLT_WaiverTOA_Current_EpicId))
            {
                refzz += member.HC_HLT_WaiverTOA_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "|" + member.HC_CoveragePeriodEnd_Current + "|" + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HLT_TiersTOA_Current_EpicId))
            {
                refzz += member.HC_HLT_TiersTOA_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "|" + member.HC_CoveragePeriodEnd_Current + "|" + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_FAC_PlanCode_Current_EpicId))
            {
                refzz += member.HC_FAC_PlanCode_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "|" + member.HC_CoveragePeriodEnd_Current + "|" + ";";
            }

            if (!string.IsNullOrEmpty(member.RiskGroup_Current_EpicId))
            {
                refzz += member.RiskGroup_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "|" + member.HC_CoveragePeriodEnd_Current + "|" + ";";
            }

            if (!string.IsNullOrEmpty(member.P35_Restorative_Indicator))
            {
                refzz += member.P35_Restorative_Indicator_EpicId + "|||" + member.P35_Restorative_Indicator + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_POS_First_Pregnancy_Current))
            {
                refzz += member.HC_POS_First_Pregnancy_Current_EpicId + "|||" + member.HC_POS_First_Pregnancy_Current + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_POS_PreferredLanguage_Current))
            {
                refzz += member.HC_POS_PreferredLanguage_Current_EpicId + "|||" + member.HC_POS_PreferredLanguage_Current + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_POS_ContactPreference_1_Current))
            {
                refzz += member.HC_POS_ContactPreference_1_Current_EpicId + "|||" + member.HC_POS_ContactPreference_1_Current + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_POS_ContactPreference_2_Current))
            {
                refzz += member.HC_POS_ContactPreference_2_Current_EpicId + "|||" + member.HC_POS_ContactPreference_2_Current + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_POS_ContactPreference_3_Current))
            {
                refzz += member.HC_POS_ContactPreference_3_Current_EpicId + "|||" + member.HC_POS_ContactPreference_3_Current + ";";
            }

            refzz += "~";

            return refzz;
        }

        /*
        private static List<string> DTP473_and_DTP474(Member_STAR_SK_Daily member)
        {
            List<string> section = new List<string>();

            if (!string.IsNullOrEmpty(member.MedicaidBegin_1))
            {
                section.Add("DTP*473*D8*" + member.MedicaidBegin_1 + "~");
            }
            // We decided to keep End Date in Dailies per Matt
            if (!string.IsNullOrEmpty(member.MedicaidEnd_1))
            {
                section.Add("DTP*474*D8*" + member.MedicaidEnd_1 + "~");
            }

            return section;
        }
        */

        private static string NM1IL(Member_STAR_SK_Daily member)
        {
            return "NM1*IL*1*" + member.Member_LastName + "*" + member.Member_FirstName + "*" + member.Member_MiddleName + "*" + member.Member_Prefix + "*" + member.Member_Suffix + "*34*" + member.SSN + "~";
        }

        private static string PERIP(Member_STAR_SK_Daily member)
        {
            return "PER*IP**" + member.Member_Comm_Qualifier_1 + "*" + member.Member_Comm_Number_1 + "*" + member.Member_Comm_Qualifier_2 + "*" + member.Member_Comm_Number_2 + "*" + member.Member_Comm_Qualifier_3 + "*" + member.Member_Comm_Number_3 + "~";
        }

        private static string N3Member(Member_STAR_SK_Daily member)
        {
            return "N3*" + member.Member_Address_1 + "*" + member.Member_Address_2 + "~";
        }

        private static string N4Member(Member_STAR_SK_Daily member)
        {
            return "N4*" + member.Member_City + "*" + member.Member_State + "*" + member.Member_PostalCode + "*" + member.Member_CountryCode + "**" + member.Member_CountyCode + "~";
        }

        private static string DMGD8(Member_STAR_SK_Daily member)
        {
            return "DMG*D8*" + member.Member_Demographics_BirthDate + "*" + member.Member_Demographics_GenderCode + "*" + member.Member_Demographics_MaritalStatusCode + "*" + member.Member_Demographics_RaceEthnicityCode + "~";
        }

        private static string LUI(Member_STAR_SK_Daily member)
        {
            return "LUI*LE*" + member.Member_Language_IdentificationCode + "**" + member.Member_Language_UseIndicator + "~";
        }

        private static string NM131()
        {
            return "NM1*31*1~";
        }

        private static string N3Mailing(Member_STAR_SK_Daily member)
        {
            return "N3*" + member.Member_MailingAddress_1 + "*" + member.Member_MailingAddress_2 + "~";
        }

        private static string N4Mailing(Member_STAR_SK_Daily member)
        {
            return "N4*" + member.Member_MailingCity + "*" + member.Member_MailingState + "*" + member.Member_MailingPostalCode + "*" + member.Member_MailingCountryCode + "~";
        }

        private static string NM1S3(Member_STAR_SK_Daily member)
        {
            return "NM1*S3*1*" + member.Member_CustodialParent_LastName + "*" + member.Member_CustodialParent_FirstName + "*" + member.Member_CustodialParent_MiddleName + "~";
        }

        private static string NM1QD(Member_STAR_SK_Daily member)
        {
            /*
             *  Requested by Joe Cecil 2/8/19 - If member is AAPCA, and member's name matches responsible person, and member's age < 18 years old, put Custodial Parent name
             */

            if (member.Employer_Group.Contains("AAPCA") && member.Member_Name_Equals_Responsible_Party_Name() && member.Member_Age() < 18)
            {
                return "NM1*QD*1*" + member.Member_CustodialParent_LastName + "*" + member.Member_CustodialParent_FirstName + "*" + member.Member_CustodialParent_MiddleName + "~";
            }
            else
            {
                return "NM1*QD*1*" + member.Member_ResponsiblePerson_LastName + "*" + member.Member_ResponsiblePerson_FirstName + "*" + member.Member_ResponsiblePerson_MiddleName + "*" + member.Member_ResponsiblePerson_Prefix + "*" + member.Member_ResponsiblePerson_Suffix + "*ZZ*" + member.Member_ResponsiblePerson_MedicaidNumber + "~";
            }
        }

        private static string PERRP(Member_STAR_SK_Daily member)
        {
            return "PER*RP**" + member.Member_ResponsiblePersonComm_Qualifier_1 + "*" + member.Member_ResponsiblePersonComm_Number_1 + "*" + member.Member_ResponsiblePersonComm_Qualifier_2 + "*" + member.Member_ResponsiblePersonComm_Number_2 + "*" + member.Member_ResponsiblePersonComm_Qualifier_3 + "*" + member.Member_ResponsiblePersonComm_Number_3 + "~";
        }

        private static List<string> HD021_or_HD024(Member_STAR_SK_Daily member, string PlanCode)
        {
            List<string> section = new List<string>();

            if (string.Equals(member.ReasonType, "024"))
            {
                section.Add("HD*024**HLT*~");
                section.Add("DTP*349*D8*" + member.HC_CoveragePeriodEnd_Current + "~");
            }
            else
            {
                section.Add("HD*021**HLT*~");
                section.Add("DTP*348*D8*" + member.HC_CoveragePeriodBegin_Current + "~");
                section.Add("DTP*349*D8*" + member.HC_CoveragePeriodEnd_Current + "~");
            }

            return section;
        }

        private static List<string> LX1(Member_STAR_SK_Daily member)
        {
            List<string> section = new List<string>();

            section.Add("LX*1~");
            section.Add("NM1*P3*1******XX*" + member.Provider_NPI + "*72~");
            //section.Add("N3*" + member.Provider_Address + "~");
            //section.Add("N4*" + member.Provider_City + "*" + member.Provider_State + "*" + member.Provider_PostalCode + "~");
            section.Add("PLA*" + member.Provider_ActionCode + "*" + member.Provider_EntityIdentifierCode + "*" + member.Provider_EffectiveDate + "**" + member.Provider_MaintenanceReasonCode + "~");

            return section;
        }

        private static List<string> LX2(Member_STAR_SK_Daily member)
        {
            List<string> section = new List<string>();

            section.Add("LX*2~");
            section.Add("NM1*FA*1******SV*" + member.EPIC_Location_ID + "~");

            return section;
        }
    }
}
