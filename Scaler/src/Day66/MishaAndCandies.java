package Day66;

import java.util.*;

public class MishaAndCandies {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		//int[] A = new int[] { 3, 2, 3 };
		int[] A = new int[] { 4, 7, 7, 2 };
		int B = 4;
		int ans = new MishaAndCandies().solve(A, B);

	}

	class Pair {
		int index;
		int candies;

		public Pair(int i, int c) {
			index = i;
			candies = c;
		}
	};

	Comparator<Pair> SortbyCandies = new Comparator<Pair> 
	{ 
	    public int compare(Pair a, Pair b) 
	    { 
	    	return a.candies - b.candies; 
	    } 
	};
	
	Comparator<Pair> SortbyIndex = new Comparator<Pair>
	{ 
	    public int compare(Pair a, Pair b) 
	    { 
	    	if (a.candies == b.candies) {
	    		return 0;
	    	}
	    	return a.index - b.index;
	    } 
	};
	
	public int solve(int[] A, int B) {
		int N = A.length;
		int ans;
		List<Pair> pq = new ArrayList<>();
		Comparator<Pair> SortbyCandies = new Comparator<Pair> 
		{ 
			@Override
		    public int  ompare(Pair a, Pair b) 
		    { 
		    	return a.candies - b.candies; 
		    } 
		};
		
		
		
		
		for (int i = 0; i < N; i++) {
			pq.add(new Pair(i, A[i]));
		}
		Collections.sort(pq, new SortbyCandies());
		Collections.sort(pq, new SortbyIndex());
		
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
	
	
}
