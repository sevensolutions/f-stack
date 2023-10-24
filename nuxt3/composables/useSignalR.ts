import { HubConnectionBuilder } from "@microsoft/signalr";
import Keycloak from "keycloak-js";

export function useSignalR(hubPath: string) {
  const nuxtApp = useNuxtApp();
  const keycloak = <Keycloak>nuxtApp.$keycloak;

  const connection = new HubConnectionBuilder()
    .withUrl(`/signalr/${hubPath}`, {
      accessTokenFactory: async () => {
        await keycloak.updateToken(5);
        return keycloak.token!;
      }
    })
    .build();

  onMounted(async () => {
    await connection.start();
  });

  onUnmounted(async () => {
    await connection.stop();
  });

  function onMessage(methodName: string, method: (...args: any[]) => any) {
    connection.on(methodName, method);
  }

  return { onMessage };
}
