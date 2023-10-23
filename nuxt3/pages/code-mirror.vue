<template>
  <div class="p-8">
    <code-mirror v-model="code" :lang="lang" :linter="linter" :extensions="[oneDark]" placeholder="Write some json here..." height="500" />
  </div>
</template>

<script setup lang="ts">
  import CodeMirror from 'vue-codemirror6';
  import { json, jsonParseLinter } from '@codemirror/lang-json';
  import { oneDark } from '@codemirror/theme-one-dark';

  const lang = json();
  const linter = jsonParseLinter();

  const code = ref(`{
  "namespace": "",
  "type": "",
  "name": "",
  "tags": {},
  "input": {
  }
}`);


</script>
