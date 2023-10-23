import TypesenseInstantSearchAdapter from "typesense-instantsearch-adapter";
import { useSystemStore } from "~/stores/system";

export function useTypesense() {
  const systemStore = useSystemStore();

  if (!systemStore.clientConfig?.typesense || !systemStore.clientConfig.typesense.isEnabled)
    return null;

  const typesenseInstantsearchAdapter = new TypesenseInstantSearchAdapter({
    server: {
      apiKey: systemStore.clientConfig.typesense.apiKey, // Be sure to use an API key that only allows search operations
      nodes: [
        {
          host: systemStore.clientConfig.typesense.host,
          path: systemStore.clientConfig.typesense.path || "",
          port: systemStore.clientConfig.typesense.port,
          protocol: systemStore.clientConfig.typesense.protocol
        }
      ],
      cacheSearchResultsForSeconds: 2 * 60, // Cache search results from server. Defaults to 2 minutes. Set to 0 to disable caching.
    },
    // The following parameters are directly passed to Typesense's search API endpoint.
    //  So you can pass any parameters supported by the search endpoint below.
    //  query_by is required.
    additionalSearchParameters: {
      query_by: "title",
    },
  });

  const searchClient = typesenseInstantsearchAdapter.searchClient;

  return { searchClient };
}
