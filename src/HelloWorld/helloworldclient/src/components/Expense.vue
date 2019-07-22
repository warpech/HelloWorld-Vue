<template>
  <div>
    <input v-model="value.Description$">
    <input v-model="value.Amount$">
  </div>
</template>

<script>
export default {
  name: 'Expense',
  props: {
    value: Object // the name of the prop must be "value" to work with v-model in the parent component
  }
}
</script>