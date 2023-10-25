import { onMounted, onUnmounted } from 'vue';

export function useInterval(callback: () => void, intervalMs = 1000) {
  let timer: any = null;

  function start() {
    stop();
    timer = setInterval(callback, intervalMs);
  }

  function stop() {
    if (timer) {
      clearInterval(timer);
      timer = null;
    }
  }

  onMounted(start);
  onUnmounted(stop);

  return { start, stop };
}
