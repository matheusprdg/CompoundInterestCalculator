import Vue from "vue";
import currencyFilter from "./currency";

export default function setup() {
    Vue.filter('currency', currencyFilter);
}