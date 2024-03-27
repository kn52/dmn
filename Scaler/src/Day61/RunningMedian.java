package Day61;

import java.util.*;

public class RunningMedian {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public static ArrayList<Integer> solve(ArrayList<Integer> A) {
		PriorityQueue<Integer> h1 = new PriorityQueue<>(Collections.reverseOrder());
		PriorityQueue<Integer> h2 = new PriorityQueue<>();

		ArrayList<Integer> ans = new ArrayList<>();

		h1.add(A.get(0));
		ans.add(A.get(0));

		for (int i = 1; i < A.size(); i++) {
			int element = A.get(i);
			if (element < h1.peek()) {
				h1.add(element);
			} else {
				h2.add(element);
			}

			int diff = Math.abs(h1.size() - h2.size());

			if (diff > 1) {
				if (h1.size() > h2.size()) {
					h2.add(h1.poll());
				} else {
					h1.add(h2.poll());
				}
			}

			if (h1.size() > h2.size()) {
				ans.add(h1.peek());
			} else {
				ans.add(h2.peek());
			}
		}

		return ans;
	}

}
