<template>
  <div class="error-container">
    <b-alert
      v-for="(mensagem, index) in getError"
      :key="index" 
      class="error floating-alert"
      :show="dismissCountDowns[index] > 0"
      dismissible
      variant="danger"
      @dismissed="removeError(index)"
      @dismiss-count-down="countDownChanged(index, $event)"
    >
      {{ mensagem }}
    </b-alert>
  </div>
</template>

<script>
import { mapState } from 'vuex';

export default {
  name: "ModalError",
  data() {
    return {
      dismissCountDowns: [],
    };
  },
  computed: {
    ...mapState(['errors']),
    getError() {
      return this.errors || [];
    }
  },
  watch: {
    getError: {
      immediate: true,
      handler(newErrors) {
        this.dismissCountDowns = newErrors.map(() => 5);
      },
    },
  },
  methods: {
    removeError(index) {
      this.$store.commit('CLEAR_ERROR', index);
      this.dismissCountDowns.splice(index, 1);
    },
    countDownChanged(index, newCountDown) {
      this.$set(this.dismissCountDowns, index, newCountDown);
    },
  },
};
</script>

<style>
  .error-container {
    position: fixed;
    right: 10px;
    top: 10px;
    z-index: 1000; 
  }

  .error  {
    margin-bottom: 10px;
    height: 70px !important;
  }
</style>

