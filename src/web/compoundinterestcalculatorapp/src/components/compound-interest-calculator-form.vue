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
        <h5 class="mb-1 text-left text-primary font-weight-bolder">
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
                      v-model="input.initialValue"
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
                      v-model="input.interestRate"
                      class="mb-sm-0"
                      placeholder="12,00"
                      type="number"
                    >
                    </b-form-input>
                    <b-input-group-append>
                      <b-form-select
                        v-model="input.interestType"
                        :options="options"
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
                        :options="options"
                      ></b-form-select>
                    </b-input-group-append>
                  </b-input-group>
                </b-form-group>
              </b-form>
            </b-col>
          </b-row>
          <b-row align-h="between" class="mt-3">
            <b-col cols="auto">
              <b-button size="lg" class="pr-5 pl-5" pill variant="primary"
                >Calcular</b-button
              >
            </b-col>
            <b-col cols="auto">
              <button class="btn btn-link js-btn-reset-form">Limpar</button>
            </b-col>
          </b-row>
        </div>
      </b-jumbotron>
    </b-container>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class CompoundInterestCalculatorForm extends Vue {
  // @Prop() private msg!: string;

  public input: CompoundInterestCalculatorInput = {
    initialValue: 0,
    monthlyValue: 0,
    interestRate: 0,
    interestType: 1,
    period: 1,
    periodType: 1,
  };

  public options = [
    { value: 1, text: "Anual" },
    { value: 2, text: "Mensal" },
  ];
}

export interface CompoundInterestCalculatorInput {
  initialValue?: number | null;
  monthlyValue?: number | null;
  interestRate: number | null;
  interestType: InterestType;
  period: number;
  periodType: PeriodType;
}

export enum InterestType {
  annual = 1,
  monthly = 2,
}

export enum PeriodType {
  annual = 1,
  monthly = 2,
}
</script>
