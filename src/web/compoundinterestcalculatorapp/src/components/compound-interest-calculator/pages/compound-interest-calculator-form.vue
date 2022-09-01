<template>
  <div>
    <b-container class="mt-2">
      <h2 class="mt-4 text-left">Calculadora de Juros Compostos</h2>
      <h6 class="text-left mb-4">
        Os juros compostos crescem de forma exponencial, pois sua base de
        cálculo é sempre em cima do montante anterior. Faça esse cálculo
        financeiro de forma simples utilizando nossa calculadora!
      </h6>
      <b-jumbotron class="bg-light pl-3 pr-3 pt-4 pb-4" border-variant="gray">
        <h5 class="mb-0 text-left text-primary font-weight-bolder">
          Simulador de Juros Compostos
        </h5>
        <div>
          <b-row>
            <b-col class="col-12 col-lg-6">
              <b-form>
                <b-form-group
                  class="text-left mt-4"
                  label="Valor inicial"
                  label-for="initial-value"
                >
                  <b-input-group prepend="R$">
                    <b-form-input
                      id="initial-value"
                      v-model="input.initialContribution"
                      placeholder="1,000"
                      type="number"
                    >
                    </b-form-input>
                  </b-input-group>
                </b-form-group>
              </b-form>
            </b-col>
            <b-col class="col-12 col-lg-6">
              <b-form>
                <b-form-group
                  class="text-left mt-4"
                  label="Valor mensal"
                  label-for="monthly-value"
                >
                  <b-input-group prepend="R$">
                    <b-form-input
                      id="monthly-value"
                      v-model="input.monthlyValue"
                      placeholder="1,000"
                      type="number"
                    >
                    </b-form-input>
                  </b-input-group>
                </b-form-group>
              </b-form>
            </b-col>
            <b-col class="col-12 col-lg-6">
              <b-form>
                <b-form-group
                  class="text-left mt-4"
                  label="Taxa de Juros"
                  label-for="interest-rate"
                >
                  <b-input-group prepend="%">
                    <b-form-input
                      id="interest-rate"
                      v-model="input.interestPercentage"
                      class="mb-sm-0"
                      placeholder="12,00"
                      type="number"
                    >
                    </b-form-input>
                    <b-input-group-append>
                      <b-form-select
                        v-model="input.interestType"
                        :options="interestRateOptions"
                      ></b-form-select>
                    </b-input-group-append>
                  </b-input-group>
                </b-form-group>
              </b-form>
            </b-col>
            <b-col class="col-12 col-lg-6">
              <b-form>
                <b-form-group
                  class="text-left mt-4"
                  label="Período"
                  label-for="period"
                >
                  <b-input-group>
                    <b-form-input
                      id="period"
                      v-model="input.period"
                      class="mb-2 mb-sm-0"
                      placeholder="1"
                      type="number"
                    >
                    </b-form-input>
                    <b-input-group-append>
                      <b-form-select
                        v-model="input.interestType"
                        :options="periodOptions"
                      ></b-form-select>
                    </b-input-group-append>
                  </b-input-group>
                </b-form-group>
              </b-form>
            </b-col>
          </b-row>
          <b-row align-h="between" class="mt-3">
            <b-col cols="auto">
              <b-button
                size="lg"
                class="pr-5 pl-5"
                pill
                variant="primary"
                @click="calcular"
                >Calcular</b-button
              >
            </b-col>
            <b-col cols="auto">
              <button class="btn btn-link js-btn-reset-form">Limpar</button>
            </b-col>
          </b-row>
        </div>
      </b-jumbotron>
      <compound-interest-calculator-result v-if="calculated" :output="output" />
    </b-container>
  </div>
</template>

<script lang="ts">
import "reflect-metadata";
import { Component, Prop, Vue } from "vue-property-decorator";
import { inject } from "inversify-props";
import { Symbols } from "../services";
import { CalculatorService } from "../services/calculator";
import { CompoundInterestCalculatorInput } from "../models/compound-interest-calculator-input";
import { CompoundInterestCalculatorOutput } from "../models/compound-interest-calculator-output";
import CompoundInterestCalculatorResult from "./compound-interest-calculator-result.vue";

@Component({
  components: {
    "compound-interest-calculator-result": CompoundInterestCalculatorResult,
  },
})
export default class CompoundInterestCalculatorForm extends Vue {
  @inject(Symbols.CalculatorServices)
  private calculatorService!: CalculatorService;
  private calculated = false;
  public output = {} as CompoundInterestCalculatorOutput;

  public input: CompoundInterestCalculatorInput = {
    initialContribution: null,
    monthlyValue: null,
    interestPercentage: 12,
    interestType: 1,
    period: 1,
    periodType: 1,
  };

  private interestRateOptions = [
    { value: 1, text: "Anual" },
    { value: 2, text: "Mensal" },
  ];

  private periodOptions = [
    { value: 1, text: "ano(s)" },
    { value: 2, text: "mes(es)" },
  ];

  private async calcular() {
    try {
      let result = await this.calculatorService.calculateCompoundInterest(
        this.input
      );

      this.output = result;
      this.calculated = true;
    } catch (error) {
      alert(error);
    }
  }
}
</script>
