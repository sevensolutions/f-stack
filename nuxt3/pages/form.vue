<template>
  <FormLayout>
    <TileLayout>
      <SectionLayout :width="2">XX</SectionLayout>
      <SectionLayout>
        XX
      </SectionLayout>
    </TileLayout>
    <TileLayout>
      <SectionLayout>XX</SectionLayout>
      <SectionLayout>XX</SectionLayout>
    </TileLayout>
    <SectionLayout>XX</SectionLayout>
  </FormLayout>
</template>

<script setup lang="ts">
  import FormLayout from '~/components/layouts/FormLayout.vue';
  import TileLayout from '~/components/layouts/TileLayout.vue';
  import SectionLayout from '~/components/layouts/SectionLayout.vue';
</script>
