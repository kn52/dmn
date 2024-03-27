package Day61;


import java.util.*;

public class KPlacesApart {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}
	
	public static ArrayList<Integer> solve(ArrayList<Integer> A) {
		PriorityQueue<Integer> pq = new  PriorityQueue<>();
		ArrayList<Integer> ans = new ArrayList<>();
		
		for (int i = 0; i < A.size(); i++) {
			pq.add(A.get(i));
		}
		
		for (int i = 0; i < pq.size(); i++) {
			ans.add(pq.peek());
			pq.remove();
		}
		
		return ans;
	}

}
