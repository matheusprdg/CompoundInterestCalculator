<template>
  <div>
    <compound-interest-calculator-form />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import CompoundInterestCalculatorForm from "../components/compound-interest-calculator-form.vue";

@Component({
  components: {
    "compound-interest-calculator-form": CompoundInterestCalculatorForm,
  },
})
export default class HomeView extends Vue {}
</script>
