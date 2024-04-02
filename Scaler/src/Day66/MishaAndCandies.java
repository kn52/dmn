package Day66;

import java.util.*;

public class MishaAndCandies {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		//int[] A = new int[] { 3, 2, 3 };
		int[] A = new int[] { 7, 4, 7, 2 };
		int B = 4;
		int ans = new MishaAndCandies().solve(A, B);

	}
	
	public int solve(int[] A, int B) {
		int N = A.length;
		int ans;
		List<Pair> pq = new ArrayList<>();
		
		for (int i = 0; i < N; i++) {
			pq.add(new Pair(i, A[i]));
		}
		Collections.sort(pq, new SortCandies());
		
		ans= 0;
		while (!pq.isEmpty()) {
			Pair p = pq.getFirst();
			if (p.candies > B) {
				break;
			}
			pq.removeFirst();
			
			int eatencandies = 0;
			
			if (p.candies % 2 == 0) {
				eatencandies = p.candies / 2;
			} else {
				eatencandies = (int) Math.floor(p.candies / 2);
			}
			
			int remainingcandies = p.candies - eatencandies;
			ans += eatencandies;
			
			if (pq.size() > 0) {
				Pair q = pq.removeFirst();
				q.candies += remainingcandies;
				pq.add(q);
			}
		}
		return ans;
	}
	
	class SortCandies implements Comparator<Pair> {
		@Override
		public int compare(Pair o1, Pair o2) {
			if (o1.candies == o2.candies) {
				return o1.index - o2.index;
			}
			return o1.candies - o2.candies;
		}
	}
	
	class Pair {
		int index;
		int candies;

		public Pair(int i, int c) {
			index = i;
			candies = c;
		}
	};
}