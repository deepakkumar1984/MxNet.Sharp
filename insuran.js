function ShowHideTabsForCase() {
    var isCrmForTablets = (Xrm.Page.context.client.getClient() !== "Mobile");
    if (isCrmForTablets) {
        var varCaseType = Common.GetOptionSetValue("oakton_casetype");
        var varDisabType = Common.GetOptionSetValue("oakton_tpdcasetype");
        if (varCaseType !== null && varDisabType !== null) {

            Common.ShowTab("MembershipDetails", true);
            Common.ShowTab("EmploymentDetails", true);

            switch (varCaseType) {
                case 425320000:
                    showHideTabsForDeathClaim();
                    break;
                case 425320001:
                    Common.ShowSection("MembershipDetails", "BeneficiaryDetails", false);
                    Common.ShowSection("MembershipDetails", "ClaimantDetails", false);
                    Common.ShowSection("MembershipDetails", "DependentsDetails", false);
                    Common.ShowSection("MembershipDetails", "TPDWorkflow", false);

                    // process for Disabilty Types
                    switch (varDisabType) {
                        case 425320000:
                            showHideTabsForTI();
                            break;
                        case 425320001:
                            showHideTabsForPI();
                            break;
                        case 425320002:
                            showHideTabsForTTD();
                            break;
                        case 425320003:
                            showHideTabsForTPD();
                            break;
                        default:
                            showHideTabsForDeathClaim();
                            break;
                    }
                    break;
                default:
                    showHideTabsForDeathClaim();
                    break;

            }
        }
        else {
            showHideTabsForDeathClaim();
        }


    }
}


function showHideTabsForDeathClaim() {
    Common.ShowTab("MembershipDetails", true);
    Common.ShowSection("MembershipDetails", "BeneficiaryDetails", true);
    Common.ShowSection("MembershipDetails", "ClaimantDetails", true);
    Common.ShowSection("MembershipDetails", "DependentsDetails", true);
    Common.ShowSection("MembershipDetails", "TPDWorkflow", false);
    Common.ShowTab("EmploymentDetails", true);
    Common.ShowSection("EmploymentDetails", "Occupation", true);
    Common.ShowTab("BenefitAmount", true);
    Common.ShowSection("BenefitAmount", "Dependants", true);
    Common.ShowTab("DocumentsReceived", true);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedDC", true);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedTI", false);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedPI", false);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedAll", true);
    Common.ShowTab("SummaryofCircumstancesandRelationships", true);
    //Common.ShowTab("InsuranceSpecialistProposal", true);
    //Common.ShowTab("BenefitsDistribution", true);
    Common.ShowSection("InsuranceSpecialistProposal", "BenDistribution", true);
    Common.ShowTab("SummaryofInjuryIllnessPreventingWork", false);
    Common.ShowTab("ClaimDetails", false);
    Common.ShowTab("CommitteeDecision", true);
    Common.ShowTab("OOB_FIELDS_TAB", false);
}

function showHideTabsForTI() {
    Common.ShowTab("MembershipDetails", true);
    Common.ShowSection("MembershipDetails", "BeneficiaryDetails", false);
    Common.ShowSection("MembershipDetails", "ClaimantDetails", false);
    Common.ShowSection("MembershipDetails", "DependentsDetails", false);
    Common.ShowSection("MembershipDetails", "TPDWorkflow", false);
    Common.ShowTab("EmploymentDetails", true);
    Common.ShowSection("EmploymentDetails", "Occupation", true);
    Common.ShowTab("BenefitAmount", true);
    Common.ShowSection("BenefitAmount", "Dependants", false);
    Common.ShowTab("DocumentsReceived", true);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedDC", false);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedTI", true);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedPI", false);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedAll", true);
    Common.ShowTab("SummaryofCircumstancesandRelationships", false);
    //Common.ShowTab("InsuranceSpecialistProposal", true);
    //Common.ShowTab("BenefitsDistribution", true);
    Common.ShowSection("InsuranceSpecialistProposal", "BenDistribution", false);
    Common.ShowTab("SummaryofInjuryIllnessPreventingWork", true);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "MedicalCertificate1", false);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "MedicalCertificate2", false);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "Actions", false);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "MedicalInformationSpecialist", true);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "MedicalInformationDoctor", true);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "Actions2", true);
    Common.ShowTab("ClaimDetails", false);
    Common.ShowTab("CommitteeDecision", true);
    Common.ShowTab("OOB_FIELDS_TAB", false);
}

function showHideTabsForPI() {
    Common.ShowTab("MembershipDetails", true);
    Common.ShowSection("MembershipDetails", "BeneficiaryDetails", false);
    Common.ShowSection("MembershipDetails", "ClaimantDetails", false);
    Common.ShowSection("MembershipDetails", "DependentsDetails", false);
    Common.ShowSection("MembershipDetails", "TPDWorkflow", false);
    Common.ShowTab("EmploymentDetails", true);
    Common.ShowSection("EmploymentDetails", "Occupation", true);
    Common.ShowTab("BenefitAmount", true);
    Common.ShowSection("BenefitAmount", "Dependants", false);
    Common.ShowTab("DocumentsReceived", true);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedDC", false);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedTI", false);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedPI", true);
    Common.ShowSection("DocumentsReceived", "DocumentsReceivedAll", true);
    Common.ShowTab("SummaryofCircumstancesandRelationships", false);
    //Common.ShowTab("InsuranceSpecialistProposal", true);
    //Common.ShowTab("BenefitsDistribution", true);
    Common.ShowSection("InsuranceSpecialistProposal", "BenDistribution", false);
    Common.ShowTab("SummaryofInjuryIllnessPreventingWork", true);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "MedicalCertificate1", true);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "MedicalCertificate2", true);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "Actions", true);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "MedicalInformationSpecialist", false);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "MedicalInformationDoctor", false);
    Common.ShowSection("SummaryofInjuryIllnessPreventingWork", "Actions2", false);
    Common.ShowTab("ClaimDetails", false);
    Common.ShowTab("CommitteeDecision", true);
    Common.ShowTab("OOB_FIELDS_TAB", false);
}

function showHideTabsForTTD() {
    Common.ShowTab("MembershipDetails", true);
    Common.ShowSection("MembershipDetails", "BeneficiaryDetails", false);
    Common.ShowSection("MembershipDetails", "ClaimantDetails", false);
    Common.ShowSection("MembershipDetails", "DependentsDetails", false);
    Common.ShowSection("MembershipDetails", "TPDWorkflow", false);
    Common.ShowTab("EmploymentDetails", true);
    Common.ShowSection("EmploymentDetails", "Occupation", true);
    Common.ShowTab("BenefitAmount", true);
    Common.ShowSection("BenefitAmount", "Dependants", false);
    Common.ShowTab("DocumentsReceived", false);
    Common.ShowTab("SummaryofCircumstancesandRelationships", false);
    //Common.ShowTab("InsuranceSpecialistProposal", true);
    //Common.ShowTab("BenefitsDistribution", false);
    Common.ShowSection("InsuranceSpecialistProposal", "BenDistribution", false);
    Common.ShowTab("SummaryofInjuryIllnessPreventingWork", false);
    Common.ShowTab("ClaimDetails", false);
    Common.ShowTab("CommitteeDecision", false);
    Common.ShowTab("OOB_FIELDS_TAB", false);
}

function showHideTabsForTPD() {
    Common.ShowTab("MembershipDetails", true);
    Common.ShowSection("MembershipDetails", "BeneficiaryDetails", false);
    Common.ShowSection("MembershipDetails", "ClaimantDetails", false);
    Common.ShowSection("MembershipDetails", "DependentsDetails", false);
    Common.ShowSection("MembershipDetails", "TPDWorkflow", true);
    Common.ShowTab("EmploymentDetails", true);
    Common.ShowSection("EmploymentDetails", "Occupation", true);
    Common.ShowTab("BenefitAmount", true);
    Common.ShowSection("BenefitAmount", "Dependants", false);
    Common.ShowTab("DocumentsReceived", false);
    Common.ShowTab("SummaryofCircumstancesandRelationships", false);
    //Common.ShowTab("InsuranceSpecialistProposal", true);
    //Common.ShowTab("BenefitsDistribution", true);
    Common.ShowSection("InsuranceSpecialistProposal", "BenDistribution", false);
    Common.ShowTab("SummaryofInjuryIllnessPreventingWork", false);
    Common.ShowTab("ClaimDetails", true);
    Common.ShowTab("CommitteeDecision", true);
    Common.ShowTab("OOB_FIELDS_TAB", false);
}

