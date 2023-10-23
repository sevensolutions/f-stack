export function useApiClient() {
  const nuxtApp = useNuxtApp();

  async function get(resourceUri: string) {
    const resourcesResponse = await fetch(`/api/${resourceUri}`, {
      method: "GET",
      headers: {
        //"Authorization": `Bearer ${nuxtApp.$keycloak.token}`
      }
    });

    const json = await resourcesResponse.json();

    return json;
  }

  async function post(resourceUri: string, request: any) {
    const resourcesResponse = await fetch(`/api/${resourceUri}`, {
      method: "POST",
      headers: {
        //"Authorization": `Bearer ${nuxtApp.$keycloak.token}`,
        "Content-Type": "application/json",
      },
      cache: "no-cache",
      body: JSON.stringify(request)
    });

    const json = await resourcesResponse.json();

    if (resourcesResponse.status !== 200) {
      throw new Error(json.title, { cause: json.detail });
    }

    return json;
  }

  async function postFormData(resourceUri: string, formData: FormData) {
    const resourcesResponse = await fetch(`/api/${resourceUri}`, {
      method: "POST",
      headers: {
        //"Authorization": `Bearer ${nuxtApp.$keycloak.token}`,
      },
      cache: "no-cache",
      body: formData
    });

    const json = await resourcesResponse.json();

    if (resourcesResponse.status !== 200) {
      throw new Error(json.title, { cause: json.detail });
    }

    return json;
  }

  return { get, post, postFormData };
}
