import { CompoundInterestCalculatorInput } from "../../models/compound-interest-calculator-input";
import { CompoundInterestCalculatorOutput } from "../../models/compound-interest-calculator-output";
import { CalculatorService } from "./calculator-service";
import http from 'axios';
import { injectable } from "inversify-props";

@injectable()
export class CalculatorServiceImpl implements CalculatorService {
  private axios = http;
  private basePath =
    process.env.NODE_ENV == "production"
      ? "https://matheusprdg-calculator.herokuapp.com"
      : "https://localhost:7298";

  public async calculateCompoundInterest(input: CompoundInterestCalculatorInput): Promise<CompoundInterestCalculatorOutput> {
    const result = (await this.axios.get<CompoundInterestCalculatorOutput>
      (`${this.basePath}/api/compoundInterest/calculate`, { params: input }));

    return result.data;
  }
}