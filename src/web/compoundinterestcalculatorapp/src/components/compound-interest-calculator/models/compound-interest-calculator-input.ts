export interface CompoundInterestCalculatorInput {
    initialContribution?: number | null;
    monthlyValue?: number | null;
    interestPercentage: number | null;
    interestType: number;
    period: number;
    periodType: number;
}

export enum InterestType {
    annual = 1,
    monthly = 2,
}

export enum PeriodType {
    annual = 1,
    monthly = 2,
}