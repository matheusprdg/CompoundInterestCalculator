<template>
  <div>
    <b-container class="mt-2">
      <h2 class="mt-4 text-left">Calculadora de Juros Compostos</h2>
      <h6 class="text-left mb-4">
        Os juros compostos crescem de forma exponencial, pois sua base de
        cálculo é sempre em cima do montante anterior. Faça esse cálculo
        financeiro de forma simples utilizando nossa calculadora!
      </h6>
      <b-overlay :show="calculating" rounded="sm">
        <template #overlay>
          <div class="text-center">
            <b-spinner
              variant="primary"
              type="grow"
              label="Spinning"
            ></b-spinner>
            <p class="font-weight-bold">Calculando...</p>
          </div>
        </template>
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
                      <currency-input
                        :id="'initial-value'"
                        v-model.number="input.initialContribution"
                        :placeHolder="'1.000,00'"
                      ></currency-input>
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
                      <currency-input
                        :id="'monthly-value'"
                        v-model.number="input.monthlyValue"
                        :placeHolder="'1.000,00'"
                      ></currency-input>
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
                      <currency-input
                        :id="'interest-rate'"
                        v-model.number="input.interestPercentage"
                        :placeHolder="''"
                      >
                      </currency-input>
                      <b-input-group-append>
                        <b-form-select
                          v-model.number="input.interestType"
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
                        v-model.number="input.period"
                        class="mb-2 mb-sm-0 font-weight-bold"
                        placeholder="1"
                        type="number"
                      >
                      </b-form-input>
                      <b-input-group-append>
                        <b-form-select
                          v-model="input.periodType"
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
                  @click="calculate"
                >
                  Calcular
                </b-button>
              </b-col>
              <b-col cols="auto">
                <button class="btn btn-link js-btn-reset-form">Limpar</button>
              </b-col>
            </b-row>
          </div>
        </b-jumbotron>
      </b-overlay>
      <compound-interest-calculator-result v-if="calculated" :output="output" />
    </b-container>
  </div>
</template>

<script lang="ts">
import "reflect-metadata";
import { Component, Vue } from "vue-property-decorator";
import { inject } from "inversify-props";
import { Symbols } from "../services";
import { CalculatorService } from "../services/calculator";
import { CompoundInterestCalculatorInput } from "../models/compound-interest-calculator-input";
import { CompoundInterestCalculatorOutput } from "../models/compound-interest-calculator-output";
import CompoundInterestCalculatorResult from "./compound-interest-calculator-result.vue";
import CurrencyInput from "../../currency-input/currency-input.vue";

@Component({
  components: {
    "compound-interest-calculator-result": CompoundInterestCalculatorResult,
    "currency-input": CurrencyInput,
  },
})
export default class CompoundInterestCalculatorForm extends Vue {
  @inject(Symbols.CalculatorServices)
  private calculatorService!: CalculatorService;
  private calculated = false;
  private calculating = false;
  public output = {} as CompoundInterestCalculatorOutput;

  public input: CompoundInterestCalculatorInput = {
    initialContribution: null,
    monthlyValue: null,
    interestPercentage: null,
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

  private async calculate() {
    try {
      this.calculating = true;
      this.output = await this.calculatorService.calculateCompoundInterest(
        this.input
      );
      this.calculating = false;
      this.calculated = true;
    } catch (error) {
      let errorMessage = error.response.data?.message;

      if (errorMessage) {
        alert(errorMessage);
      } else {
        alert(error.message);
      }

      this.calculating = false;
    }
  }
}
</script>