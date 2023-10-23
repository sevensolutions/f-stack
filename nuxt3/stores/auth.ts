import { defineStore } from 'pinia';

export const useAuthStore = defineStore('auth', () => {
  const accountInfo = ref({});

  function updateAccountInfo(value: any) {
    accountInfo.value = value;
  }

  return {
    accountInfo,
    updateAccountInfo
  };
});
