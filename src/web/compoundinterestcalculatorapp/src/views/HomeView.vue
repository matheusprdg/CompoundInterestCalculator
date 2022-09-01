<template>
  <div>
    <compound-interest-calculator-form />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import CompoundInterestCalculatorForm from "../components/compound-interest-calculator/pages/compound-interest-calculator-form.vue";
import CompoundInterestCalculatorResult from "../components/compound-interest-calculator/pages/compound-interest-calculator-result.vue";

@Component({
  components: {
    "compound-interest-calculator-form": CompoundInterestCalculatorForm,
    "compound-interest-calculator-result": CompoundInterestCalculatorResult,
  },
})
export default class HomeView extends Vue {}
</script>
