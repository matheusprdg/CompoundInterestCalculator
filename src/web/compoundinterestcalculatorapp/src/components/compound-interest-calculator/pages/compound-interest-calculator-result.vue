<template>
  <div>
    <b-jumbotron class="bg-light pl-3 pr-3 pt-4 pb-4" border-variant="gray">
      <h5 class="mb-4 text-left text-primary font-weight-bolder">Resultado</h5>
      <b-row>
        <b-col class="col-12 col-lg-4 text-center">
          <div class="border rounded bg-white p-3">
            <p class="text-muted">Valor total final</p>
            <div class="h4 mb-0 font-weight-bold text-truncate text-muted">
              {{ output.finalTotalValue | currency }}
            </div>
          </div>
        </b-col>
        <b-col class="col-12 col-lg-4 text-center"
          ><div class="border rounded bg-white p-3">
            <p class="text-muted">Valor total investido</p>
            <div class="h4 mb-0 font-weight-bold text-truncate text-primary">
              {{ output.totalAmountInvested | currency }}
            </div>
          </div>
        </b-col>
        <b-col class="col-12 col-lg-4 text-center"
          ><div class="border rounded bg-white p-3">
            <p class="text-muted">Total em juros</p>
            <div class="h4 mb-0 font-weight-bold text-truncate text-success">
              {{ output.totalInInterest | currency }}
            </div>
          </div>
        </b-col>
      </b-row>
      <b-row class="mt-4">
        <b-col>
          <b-card no-body>
            <b-tabs pills justified card class="tab-style">
              <b-tab title="Tabela" active class="p-0">
                <div class="tab-content">
                  <table class="table table-bordered table-hover text-center">
                    <thead>
                      <tr>
                        <th>Mês</th>
                        <th>Juros</th>
                        <th>Total Investido</th>
                        <th>Total de Juros</th>
                        <th>Total acumulado</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr v-for="(value, key) in output.details" :key="key">
                        <td>
                          {{
                            value.initialContribution
                              ? "Valor Inicial"
                              : value.month
                          }}
                        </td>
                        <td>{{ value.interest | currency }}</td>
                        <td>{{ value.totalInvested | currency }}</td>
                        <td>{{ value.totalInterest | currency }}</td>
                        <td>{{ value.accumulatedTotal | currency }}</td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </b-tab>
              <b-tab title="Gráfico"></b-tab>
            </b-tabs>
          </b-card>
        </b-col>
      </b-row>
    </b-jumbotron>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { CompoundInterestCalculatorOutput } from "../models/compound-interest-calculator-output";

@Component
export default class CompoundInterestCalculatorResult extends Vue {
  @Prop()
  public output!: CompoundInterestCalculatorOutput;
}
</script>

<style scoped>
.tab-content {
  height: 32rem;
  overflow: scroll;
}
</style>

<style>
.nav-pills .nav-item .nav-link:not(.active) {
  background-color: white;
  color: #6c757d;
  font-weight: bolder;
  border: none;
}
</style>