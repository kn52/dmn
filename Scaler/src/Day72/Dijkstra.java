package Day72;

import java.util.*;

public class Dijkstra {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int A = 6;
		int C = 4;
		int[][] B = { { 0, 4, 9 }, { 3, 4, 6 }, { 1, 2, 1 }, { 2, 5, 1 }, { 2, 4, 5 }, { 0, 3, 7 }, { 0, 1, 1 },
				{ 4, 5, 7 }, { 0, 5, 1 } };

		int[] ans = new Dijkstra().solve(A, B, C);

		System.out.println(ans);

	}

	public int[] solve(int A, int[][] B, int C) {
		List<Pair>[] adj = new ArrayList[A];
		boolean[] visited = new boolean[A];
		
		for (int i = 0; i < A; i++) {
			adj[i] = new ArrayList<Pair>();
		}

		for (int i = 0; i < B.length; i++) {
			adj[B[i][0]].add(new Pair(B[i][1], B[i][2]));
			adj[B[i][1]].add(new Pair(B[i][0], B[i][2]));
		}

		PriorityQueue<Pair> pq = new PriorityQueue<>((a, b) -> a.w - b.w);

		
		pq.add(new Pair(C, 0));
		int[] ans = new int[A];
		Arrays.fill(ans, Integer.MAX_VALUE);
		ans[C] = 0;
		
		while (!pq.isEmpty()) {
			Pair temp = pq.poll();

			if (ans[temp.v] < temp.w)
				continue;

			for (Pair nbr : adj[temp.v]) {
				if (ans[nbr.v] > ans[temp.v] + nbr.w) {
					ans[nbr.v] = ans[temp.v] + nbr.w;
					pq.add(new Pair(nbr.v, ans[nbr.v]));
				}
			}
		}

		for (int i = 0; i < ans.length; i++) {
			if (ans[i] == Integer.MAX_VALUE)
				ans[i] = -1;
		}

		return ans;
	}

	class Pair {
		int v;
		int w;

		Pair(int v, int w) {
			this.v = v;
			this.w = w;
		}
	}

}
