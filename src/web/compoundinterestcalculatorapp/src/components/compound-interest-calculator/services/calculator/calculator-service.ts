import { CompoundInterestCalculatorInput } from "../../models/compound-interest-calculator-input";
import { CompoundInterestCalculatorOutput } from "../../models/compound-interest-calculator-output";

export interface CalculatorService {
    calculateCompoundInterest(input: CompoundInterestCalculatorInput): Promise<CompoundInterestCalculatorOutput>;
}