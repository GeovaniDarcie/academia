<template>
  <div>
    <b-modal
      v-model="showModal"
      class="modal"
    >
        <ModalCadastro />
    </b-modal>

    <b-button @click="showModal=true" variant="primary">Show Modal</b-button>
  </div>
</template>

<script>
import ModalCadastro from '../Components/ModalCadastro.vue'

export default {
    data() {
        return {
            showModal: false
        }
    },
    components: {
        ModalCadastro
    }
}
</script>

<style>

</style>