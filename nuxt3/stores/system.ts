import { defineStore } from 'pinia';
import { IClientConfig } from "~/types/api";

export const useSystemStore = defineStore('system', () => {
  const clientConfig = ref<IClientConfig>({});

  function updateClientConfig(value: IClientConfig) {
    clientConfig.value = value;
  }

  return {
    clientConfig,
    updateClientConfig
  };
});
