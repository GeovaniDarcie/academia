<template>
  <div>
    <b-navbar
      toggleable="lg"
      type="dark"
      variant="dark"
      fixed="top"
      class="altura-header"
    >
      <b-button v-b-toggle.sidebar-1>
        <b-icon icon="list"></b-icon>
      </b-button>
       <b-sidebar id="sidebar-1" aria-labelledby="sidebar-1" shadow>
      <template #default="{ hide }">
        <div class="p-3">
          <h4>Menu</h4>
          <nav class="mb-3">
            <b-nav vertical>
              <b-nav-item href="/avaliacao" @click="hide">Avaliação Física</b-nav-item>
            </b-nav>
          </nav>
        </div>
      </template>
    </b-sidebar>
    <template>
</template>
      <b-navbar-brand href="#" class="ml-5 font-header"
        >Academia</b-navbar-brand
      >
      <hr />
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
            <b-nav-item href="#">Alunos</b-nav-item>
            <b-form-input
              size="sm"
              class="mr-sm-2"
              placeholder="Pesquisar"
            ></b-form-input>
            <b-button
              pill
              size="sm"
              class="my-2 my-sm-0"
              type="submit"
              variant="info"
              >Buscar</b-button
            >
          </b-nav-form>

          <b-nav-item-dropdown right>
            <!-- Using 'button-content' slot -->
            <template #button-content>
              <em>usuário</em>
            </template>
            <b-dropdown-item href="#">Perfil</b-dropdown-item>
            <b-dropdown-item href="#">Sair</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<style scoped>
.altura-header {
  height: 90px;
}

.font-header {
  font-size: 3rem;
  font-family: "Text Me One", sans-serif;
}
</style>
