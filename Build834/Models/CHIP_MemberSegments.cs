using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build834.Models
{
    public class CHIP_MemberSegments
    {

        public static List<string> BuildMemberSegments(Member_CHIP member, string PlanCode)
        {
            List<string> memberSegment = new List<string>();

            memberSegment.Add(INSSegment(member));
            memberSegment.Add(REF0F(member));
            memberSegment.Add(REF1L(member));
            memberSegment.Add(REF23(member));
            memberSegment.Add(REFZZ(member));
            if (!string.Equals(member.ReasonType, "024"))
            {
                memberSegment.Add(DTP356(member));
            }
            memberSegment.Add(DTP357(member));
            memberSegment.Add(NM1IL(member));
            memberSegment.Add(PERIP(member));
            memberSegment.Add(N3Member(member));
            memberSegment.Add(N4Member(member));
            memberSegment.Add(DMGD8(member));
            memberSegment.Add(NM131());
            memberSegment.Add(N3Mailing(member));
            memberSegment.Add(N4Mailing(member));
            memberSegment.Add(NM1QD(member));
            memberSegment.Add(PERRP(member));
            memberSegment.AddRange(HD021_or_HD024(member, PlanCode));
            memberSegment.AddRange(LX1(member));
            memberSegment.AddRange(LX2(member));
            
            return memberSegment;
        }

        private static string INSSegment(Member_CHIP member)
        {
            return "INS*Y*18*" + member.ReasonType + "*" + member.ReasonCode + "*" + member.BenefitStatus + "***" + member.SubscriberStatusCode + "~";
        }

        private static string REF0F(Member_CHIP member)
        {
            return "REF*0F*" + member.SubscriberIdentifier + "~";
        }

        private static string REF1L(Member_CHIP member)
        {
            return "REF*1L*" + member.Employer_Group + "~";
        }

        private static string REF23(Member_CHIP member)
        {
            return "REF*23*" + member.SubscriberIdentifier + "~";
        }

        private static string REFZZ(Member_CHIP member)
        {
            string refzz = "REF*ZZ*";

            if(!string.IsNullOrEmpty(member.CaseId))
            {
                refzz += member.CaseEpicId + "|||" + member.CaseId + ";";
            }

            if (!string.IsNullOrEmpty(member.AnnualEnrollDate))
            {
                refzz += member.AnnualEnrollDateEpicId + "|||" + member.AnnualEnrollDate + ";";
            }

            if (!string.IsNullOrEmpty(member.DisenrollmentReason))
            {
                refzz += member.DisenrollmentReasonEpicId + "|||" + member.DisenrollmentReason + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_Pregnancy_Flag))
            {
                refzz += member.HC_HMO_Pregnancy_Flag_EpicId + "|||" + member.HC_HMO_Pregnancy_Flag + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_Copayment_Level))
            {
                refzz += member.HC_HMO_Copayment_Level_EpicId + "|||" + member.HC_HMO_Copayment_Level + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_Renewal_Indicator))
            {
                refzz += member.HC_HMO_Renewal_Indicator_EpicId + "|||" + member.HC_HMO_Renewal_Indicator + ";";
            }

            if (!string.IsNullOrEmpty(member.HC_HMO_DentalPlan))
            {
                refzz += member.HC_HMO_DentalPlan_EpicId + "|||" + member.HC_HMO_DentalPlan + ";";
            }

            if (!string.IsNullOrEmpty(member.RiskGroup_Current_EpicId))
            {
                refzz += member.RiskGroup_Current_EpicId + "|" + member.HC_CoveragePeriodBegin_Current + "|" + member.HC_CoveragePeriodEnd_Current + "|" + ";";
            }

            if (!string.IsNullOrEmpty(member.RiskGroup_Future_EpicId))
            {
                refzz += member.RiskGroup_Future_EpicId + "|" + member.HC_CoveragePeriodBegin_Future + "||" + ";";
            }

            refzz += "~";

            return refzz;
        }

        private static string DTP356(Member_CHIP member)
        {
            return "DTP*356*D8*" + member.HC_CoveragePeriodBegin_Future + "~";
        }

        private static string DTP357(Member_CHIP member)
        {
            if (string.Equals(member.ReasonType, "024"))
            {
                return "DTP*357*D8*" + member.DisenrollmentDate + "~";
            }
            else
            {
                return "DTP*357*D8*" + member.PlanEndDate + "~";
            }
        }

        private static string NM1IL(Member_CHIP member)
        {
            return "NM1*IL*1*" + member.Member_LastName + "*" + member.Member_FirstName + "*" + member.Member_MiddleName + "*" + member.Member_Prefix + "*" + member.Member_Suffix + "*34*" + member.Member_SSN + "~";
        }

        private static string PERIP(Member_CHIP member)
        {
            return "PER*IP**" + member.Member_Comm_Qualifier + "*" + member.Member_Comm_Number + "~";
        }

        private static string N3Member(Member_CHIP member)
        {
            return "N3*" + member.Member_Address_1 + "*" + member.Member_Address_2 + "~";
        }

        private static string N4Member(Member_CHIP member)
        {
            return "N4*" + member.Member_City + "*" + member.Member_State + "*" + member.Member_PostalCode + "*" + member.Member_CountryCode + "**" + member.Member_CountyCode + "~";
        }

        private static string DMGD8(Member_CHIP member)
        {
            return "DMG*D8*" + member.Member_Demographics_BirthDate + "*" + member.Member_Demographics_GenderCode + "*" + member.Member_Demographics_MaritalStatusCode + "*" + member.Member_Demographics_RaceEthnicityCode + "~";
        }

        private static string NM131()
        {
            return "NM1*31*1~";
        }

        private static string N3Mailing(Member_CHIP member)
        {
            return "N3*" + member.Member_MailingAddress_1 + "*" + member.Member_MailingAddress_2 + "~";
        }

        private static string N4Mailing(Member_CHIP member)
        {
            return "N4*" + member.Member_MailingCity + "*" + member.Member_MailingState + "*" + member.Member_MailingPostalCode + "~";
        }

        private static string NM1QD(Member_CHIP member)
        {
            return "NM1*QD*1*" + member.Member_ResponsiblePerson_LastName + "*" + member.Member_ResponsiblePerson_FirstName + "~";
        }

        private static string PERRP(Member_CHIP member)
        {
            return "PER*RP**" + member.Member_ResponsiblePersonComm_Qualifier_1 + "*" + member.Member_ResponsiblePersonComm_Number_1 + "*" + member.Member_ResponsiblePersonComm_Qualifier_2 + "*" + member.Member_ResponsiblePersonComm_Number_2 + "*" + "~";
        }

        private static List<string> HD021_or_HD024(Member_CHIP member, string PlanCode)
        {
            List<string> section = new List<string>();

            if (string.Equals(member.ReasonType, "024"))
            {
                section.Add("HD*024**HLT*~");
                section.Add("DTP*303*D8*" + member.DisenrollmentDate + "~");
            } else
            {
                section.Add("HD*001**HLT*~");
                section.Add("DTP*303*D8*" + member.HC_CoveragePeriodBegin_Future + "~");
            }

            return section;
        }

        private static List<string> LX1(Member_CHIP member)
        {
            List<string> section = new List<string>();

            section.Add("LX*1~");
            section.Add("NM1*P3*1******XX*" + member.Provider_NPI + "*72~");
            //section.Add("N3*" + member.Provider_Address + "~");
            //section.Add("N4*" + member.Provider_City + "*" + member.Provider_State + "*" + member.Provider_PostalCode + "~");
            
            if (!string.Equals(member.ReasonType, "024"))
            {
                section.Add("PLA*" + member.Provider_ActionCode + "*" + member.Provider_EntityIdentifierCode + "*" + member.Provider_EffectiveDate + "**" + member.Provider_MaintenanceReasonCode + "~");
            }
            return section;
        }

        private static List<string> LX2(Member_CHIP member)
        {
            List<string> section = new List<string>();

            section.Add("LX*2~");
            section.Add("NM1*FA*1******SV*" + member.EPIC_Location_ID + "~");

            return section;
        }
    }
}
