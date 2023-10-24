<template>
    <div class="antialiased">
      <app-header></app-header>

      <app-navigation></app-navigation>

      <main class="md:ml-64 h-auto pt-16">
        <!-- <Breadcrumb>
          <BreadcrumbItem href="#" home>Home</BreadcrumbItem>
          <BreadcrumbItem :href="item.path" v-for="(item, index) in breadcrumbItems" :key="index">{{ item.title }}</BreadcrumbItem>
          <BreadcrumbItem>{{ $route.meta?.title || "Unknown" }}</BreadcrumbItem>
        </Breadcrumb> -->

        <slot></slot>
      </main>

      <toast-notifications></toast-notifications>
    </div>
  </template>

  <script setup lang="ts">
    import AppHeader from '~/components/shell/AppHeader.vue';
    import AppNavigation from '~/components/shell/AppNavigation.vue';
    import ToastNotifications from '~/components/shell/ToastNotifications.vue';
    import { Breadcrumb, BreadcrumbItem } from 'flowbite-vue';

    const router = useRouter();
    const route = useRoute();
    const routes = router.getRoutes();

    const breadcrumbItems = computed(() =>  {
      const segments = route.fullPath
        .split('/')
        .filter(x => x);

      segments.pop(); // Remove the last one

      return segments.map(segment => {
        const r = routes.find(x => x.path === "/" + segment);

        if (r) {
          return {
            title: r.meta?.title || r.name,
            path: r.path
          }
        }

        return {
          title: "Unknown"
        };
      });
    });
  </script>
