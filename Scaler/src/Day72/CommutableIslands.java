package Day72;

import java.util.*;

public class CommutableIslands {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int A = 4;
		int[][] B = { { 1, 2, 10 }, { 2, 3, 5 }, { 1, 3, 9 } };

		int ans = new CommutableIslands().solve(A, B);

		System.out.println(ans);
	}

	class Pair {
		int v;
		int w;

		Pair(int v, int w) {
			this.v = v;
			this.w = w;
		}
	}

	public int solve(int A, int[][] B) {
		List<Pair>[] adj = new ArrayList[A + 1];
		boolean[] visited = new boolean[A + 1];

		for (int i = 0; i <= A; i++) {
			adj[i] = new ArrayList<Pair>();
		}

		for (int i = 0; i < B.length; i++) {
			adj[B[i][0]].add(new Pair(B[i][1], B[i][2]));
			adj[B[i][1]].add(new Pair(B[i][0], B[i][2]));
		}

		PriorityQueue<Pair> pq = new PriorityQueue<>(100, new Comparator<Pair>() {
			public int compare(Pair p1, Pair p2) {
				if (p1.w < p2.w) {
					return -1;
				} else if (p1.w > p2.w) {
					return 1;
				} else {
					return 0;
				}
			}
		});

		for (int i = 0; i < adj[1].size(); i++) {
			Pair temp = adj[1].get(i);
			pq.add(new Pair(temp.v, temp.w));
		}

		visited[1] = true;
		int ans = 0;

		while (!pq.isEmpty()) {
			Pair temp = pq.poll();

			if (visited[temp.v])
				continue;

			visited[temp.v] = true;
			ans = ans + temp.w;

			for (Pair nbr : adj[temp.v]) {
				if (!visited[nbr.v]) {
					pq.add(new Pair(nbr.v, nbr.w));
				}
			}
		}
		return ans;
	}
}
