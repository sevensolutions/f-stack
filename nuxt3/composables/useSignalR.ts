import { HubConnectionBuilder } from "@microsoft/signalr";
import Keycloak from "keycloak-js";

export function useSignalR(hubPath: string) {
  const nuxtApp = useNuxtApp();
  const keycloak = <Keycloak>nuxtApp.$keycloak;

  const connection = new HubConnectionBuilder()
    .withUrl(`http://localhost:5137/signalr/${hubPath}`)
    // .withUrl(`/signalr/${hubPath}`, {
    //   accessTokenFactory: async () => {
    //     await keycloak.updateToken(5);
    //     return keycloak.token!;
    //   }
    // })
    .withAutomaticReconnect()
    .configureLogging('debug')
    .build();

  onMounted(async () => {
    try {
      console.log("SignalR connecting...");
      await connection.start();
      console.log("SignalR started");
    }
    catch(ex: any) {
      console.log("Failed to establish SignalR connection.", ex);
    }
  });

  onUnmounted(async () => {
    //await connection.stop();
  });

  function onMessage(methodName: string, method: (...args: any[]) => any) {
    connection.on(methodName, method);
  }

  function sendMessage(methodName: string, ...args: any[]) {
    connection.send(methodName, args);
  }

  return { onMessage, sendMessage };
}
