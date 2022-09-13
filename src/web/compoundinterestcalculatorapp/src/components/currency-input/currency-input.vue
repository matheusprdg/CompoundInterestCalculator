<template>
  <b-form-input :id="id" :placeholder="placeHolder" type="text" ref="inputRef">
  </b-form-input>
</template>

<script>
import { useCurrencyInput } from "vue-currency-input";

export default {
  name: "CurrencyInput",
  props: { placeHolder: String, id: String },
  setup() {
    const options = {
      hideNegligibleDecimalDigitsOnFocus: false,
      autoDecimalDigits: true,
      hideGroupingSeparatorOnFocus: false,
      locale: "pt-BR",
      precision: { min: 2, max: 2 },
      currency: "BRL",
      currencyDisplay: "hidden",
    };

    const { inputRef } = useCurrencyInput(options);

    return { inputRef };
  },
};
</script>