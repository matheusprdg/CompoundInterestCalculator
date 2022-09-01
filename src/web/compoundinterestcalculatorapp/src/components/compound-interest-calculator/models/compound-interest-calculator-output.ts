export interface CompoundInterestCalculatorOutput {
    finalTotalValue: number;
    totalAmountInvested: number;
    totalInInterest: number;
    details: CalculateCompoundInterestDetail;
}

export interface CalculateCompoundInterestDetail {
    month: number;
    interest: number;
    totalInvested: number;
    totalInterest: number;
    accumulatedTotal: number;
    initialContribution: number;
}