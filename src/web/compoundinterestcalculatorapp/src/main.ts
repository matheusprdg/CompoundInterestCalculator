import "reflect-metadata";
import Vue from "vue";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { CalculatorServicesBinder } from "./components/compound-interest-calculator/services/calculator-service-binder";
import setup from "./filters/setup";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

CalculatorServicesBinder.with();

Vue.config.productionTip = false;
Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
setup();


new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');